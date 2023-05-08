using RotFrontApplication.HelperClass;
using RotFrontApplication.Pages.Shipment;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = ConnectionPoint.connectPoint.Users.FirstOrDefault(
                    x => x.Login == TxbLogin.Text && x.Password == PsbPass.Password 
                    );

                if (data == null) 
                {
                    MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else 
                {
                    switch (data.Role_id)
                    {
                        case 1:
                            NavigateClass.frmNav.Navigate(new ShipmentAll());
                            break;
                    }
                }
            }
            catch (Exception ex)
            { 

            }
        }
    }
}
