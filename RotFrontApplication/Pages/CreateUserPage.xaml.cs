using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : Page
    {
        public CreateUserPage()
        {
            InitializeComponent();

            CmdRole.DisplayMemberPath = "Name";
            CmdRole.SelectedValuePath = "id";
            CmdRole.ItemsSource = ConnectionPoint.connectPoint.Role.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users users = new Users();
                users.SNP = TxbName.Text;
                users.Role_id = Convert.ToInt32(CmdRole.SelectedValue);
                users.Login = TxbLogin.Text;
                string hashedPassword = HashPassword(TxbPass.Text);
                users.Password = hashedPassword;
                ConnectionPoint.connectPoint.Users.AddOrUpdate(users);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Пользователь добавлен!");


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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}
