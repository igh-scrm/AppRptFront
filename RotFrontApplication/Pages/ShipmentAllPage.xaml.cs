using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для ShipmentAllPage.xaml
    /// </summary>
    public partial class ShipmentAllPage : Page
    {
        private Users authData;
        private DateTime lastPasswordChangeDate;

        public ShipmentAllPage(Users authData)
        {
            InitializeComponent();

            this.authData = authData;
            this.lastPasswordChangeDate = Convert.ToDateTime(authData.DateUpdatePass);

            GridListShipment.ItemsSource = ConnectionPoint.connectPoint.Shipment.Where(x => x.Status == 0 && x.ToAccept == authData.id).ToList();
            CheckPasswordExpiration();

        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new ShipmentPage((sender as Button).DataContext as Shipment));
        }

        private void CheckPasswordExpiration()
        {
            
            if ((DateTime.Now - lastPasswordChangeDate).Days >= 30)
            {
                // Отобразить окно смены пароля.
                MessageBoxResult result = MessageBox.Show("Ваш пароль не менялся уже больше месяца. Изменить его сейчас?", "ERP: Складской учет", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    NavigateClass.frmNav.Navigate(new ChangePass(authData));

                }
            }
        }

    }
}
