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

namespace RotFrontApplication.Pages.Shipment
{
    /// <summary>
    /// Логика взаимодействия для ShipmentAll.xaml
    /// </summary>
    public partial class ShipmentAll : Page
    {
        public ShipmentAll()
        {
            InitializeComponent();
            GridListShipment.ItemsSource = ConnectionPoint.connectPoint.Shipment.ToList();
        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
