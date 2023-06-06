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
        public ShipmentAllPage()
        {
            InitializeComponent();

            //Users authData

            GridListShipment.ItemsSource = ConnectionPoint.connectPoint.Shipment.Where(x => x.Status == 0).ToList();

            //&& x.ToAccept == authData.id

        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new ShipmentPage((sender as Button).DataContext as Shipment));
        }

    }
}
