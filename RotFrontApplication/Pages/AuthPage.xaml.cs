using Newtonsoft.Json;
using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
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

        public class ErrorButton : TextBox
        {
            public int ErrorInputCount { get; set; }
        }


        private async void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var db = ConnectionPoint.connectPoint.Users.FirstOrDefault();

                using (HttpClient client = new HttpClient())

                {

                    string login = TxbLogin.Text;
                    string password = PsbPass.Password;

                    HttpResponseMessage response = await client.GetAsync($"http://localhost:5009/api/Users?UserLogin={login}&UserPassword={password}");

                    //HttpResponseMessage message = await client.GetAsync("http://localhost:5009/api/Users?UserLogin=1&UserPassword=1");


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();


                        List<User> users = JsonConvert.DeserializeObject<List<User>>(result);


                        foreach (var user in users)
                        {
                            switch (user.UserRole)
                            {
                                case 1:
                                    NavigateClass.frmNav.Navigate(new ShipmentAllPage());
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
                                default:
                                    throw new Exception($"не изестная роль: {user.UserRole}");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
