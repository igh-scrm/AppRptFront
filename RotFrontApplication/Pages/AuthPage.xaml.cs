using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RotFrontApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

        }
        private int failedAttempts = 0;
        private int blockBtn = 0;
        private System.Windows.Threading.DispatcherTimer timer;

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hashPassword = HashPassword(PsbPass.Password);

                var data = ConnectionPoint.connectPoint.Users.FirstOrDefault(
                    x => x.Login == TxbLogin.Text && x.Password == hashPassword
                );

                if (data == null)
                {
                    failedAttempts++;
                   
                    MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                   
                }
                else
                {

                    switch (data.Role_id)
                    {
                        case 1:
                            NavigateClass.frmNav.Navigate(new ShipmentAllPage(data));
                            break;
                        case 2:
                            NavigateClass.frmNav.Navigate(new RequestAllPage());
                            break;
                        case 3:
                            NavigateClass.frmNav.Navigate(new SendingAllPage());
                            break;
                        case 4:
                            NavigateClass.frmNav.Navigate(new ShipmentAllDirPage());
                            break;
                        case 5:
                            NavigateClass.frmNav.Navigate(new AdminPage());
                            break;
                    }

                    LogHistory log = new LogHistory
                    {
                        User_id = data.id,
                        LogTime = DateTime.Now,
                        PasswordEntryAttempts = failedAttempts,
                        Success = 1,
                        CountBlockBtn = blockBtn
                    };

                    ConnectionPoint.connectPoint.LogHistory.Add(log);
                    ConnectionPoint.connectPoint.SaveChanges();



                }

                if (failedAttempts >= 3)
                {
                    blockBtn++;
                    MessageBox.Show("Вы превысили число попыток входа в систему. Попробуйте еще раз через минуту.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

                    // Блокируем страницу авторизации
                    BtnAuth.IsEnabled = false;

                    // Запускаем таймер на 60 секунд для разблокировки страницы
                    timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(60);
                    
                    timer.Tick += Timer_Tick;
                    timer.Start();


                }

               
            }
            catch (Exception ex)
            {
                // Обработка ошибок
            }
        }

        private string HashPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Разблокируем страницу авторизации и сбрасываем значение счетчика неудачных попыток
            BtnAuth.IsEnabled = true;
            failedAttempts = 0;

            // Останавливаем таймер
            timer.Stop();
        }
    }
}
