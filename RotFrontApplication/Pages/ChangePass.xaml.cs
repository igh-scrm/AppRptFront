using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RotFrontApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Page
    {
        private Users authData;

        public ChangePass(Users AuthData)
        {
            InitializeComponent();

            this.authData = AuthData;
        }

        private void BtnChangePass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //CheckPasswordStrength(PsbPass.Password);
                if (PsbPass.Password != PsbAgPass.Password)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
                else
                {
                    Users users = new Users();
                    users.id = authData.id;
                    users.SNP = authData.SNP;
                    users.Role_id = authData.Role_id;
                    users.Login = authData.Login;
                    string hashedPassword = HashPassword(PsbPass.Password);
                    users.Password = hashedPassword;
                    users.DateUpdatePass = Convert.ToDateTime(DateTime.Now);
                    users.DateAdd = authData.DateAdd;
                    ConnectionPoint.connectPoint.Users.AddOrUpdate(users);
                    ConnectionPoint.connectPoint.SaveChanges();
                    MessageBoxResult result = MessageBox.Show("Пароль изменен", "ERP: Складской учет", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        NavigateClass.frmNav.Navigate(new AuthPage());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");

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

        private void PsbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckPasswordStrength(PsbPass.Password);
        }

        private void CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length < 1) // ужасный пароль
            {
                score = 0;
            }
            else if (password.Length < 8 || !Regex.IsMatch(password, @"[a-z]") || !Regex.IsMatch(password, @"\d")) // плохой пароль
            {
                score = 1;
            }
            else if (!Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "^\\w*$")) // умеренный пароль
            {
                score = 2;
            }
            else if (!Regex.IsMatch(password, "[^a-zA-Z0-9]") || !Regex.IsMatch(password, "[A-Z]") || !Regex.IsMatch(password, "\\d") || password.Length < 10) // хороший пароль
            {
                score = 3;
            }
            else if (!Regex.IsMatch(password, "[^a-zA-Z0-9]") || !Regex.IsMatch(password, "[A-Z]") || !Regex.IsMatch(password, "\\d") || password.Length >= 10) // сильный пароль
            {
                score = 4;
            }
            else // отличный или замечательный пароль
            {
                bool good = true;

                for (int i = 0; i < password.Length - 4; i++)
                {
                    string substr = password.Substring(i, 4);

                    if (Regex.IsMatch(substr, "[A-Z]{4}"))
                    {
                        good = false;
                        break;
                    }
                }

                if (good && password.Length > 20 && Regex.Matches(password, "[^a-zA-Z0-9]").Count > 5) // замечательный пароль
                {
                    score = 5;
                }
                else if (good && Regex.Matches(password, "[^a-zA-Z0-9]").Count > 3) // отличный пароль
                {
                    score = 4;
                }
            }

            switch (score)
            {
                case 0:
                    PsbPass.BorderBrush = Brushes.Red;
                    break;
                case 1:
                    PsbPass.BorderBrush = Brushes.Orange;
                    break;
                case 2:
                    PsbPass.BorderBrush = Brushes.Yellow;
                    break;
                case 3:
                    PsbPass.BorderBrush = Brushes.GreenYellow;
                    break;
                case 4:
                    PsbPass.BorderBrush = Brushes.LimeGreen;
                    break;
                case 5:
                    PsbPass.BorderBrush = Brushes.DarkGreen;
                    break;
            }

            PsbPass.ToolTip = string.Empty;
            switch (score)
            {
                case 0:
                    PsbPass.ToolTip = "Ужасный пароль";
                    break;
                case 1:
                    PsbPass.ToolTip = "Плохой пароль";
                    break;
                case 2:
                    PsbPass.ToolTip = "Умеренный пароль";
                    break;
                case 3:
                    PsbPass.ToolTip = "Хороший пароль";
                    break;
                case 4:
                    PsbPass.ToolTip = "Сильный пароль";
                    break;
                case 5:
                    PsbPass.ToolTip = "Замечательный пароль";
                    break;
            }
        }
    }
}
