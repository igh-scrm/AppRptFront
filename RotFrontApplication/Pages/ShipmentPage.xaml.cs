using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        private Shipment _shipment { get; set; }
        private Warehouse _warehouse { get; set; }
        public ShipmentPage(Shipment shipment)
        {
            InitializeComponent();
            
            _shipment= shipment;

            TxbNumber.Text = shipment.id.ToString();
            TxbFrom.Text = shipment.Suppliers.CompanyName;
            TxbProduct.Text = shipment.Warehouse.Product_id.ToString();
            TxbCount.Text = shipment.Count.ToString();
            TxbNs.Text = shipment.Ns.Name;
            TxbExpDate.Text = shipment.Date.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RejectPage());
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = ConnectionPoint.connectPoint.Shipment.FirstOrDefault(x => x.id == _shipment.id);
                data.Status = 1;
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Статус закаа изменён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                var count = ConnectionPoint.connectPoint.Warehouse.FirstOrDefault(x => x.QuantityInStock == _warehouse.QuantityInStock);
                count.QuantityInStock += Convert.ToInt32(TxbCount.Text);
                ConnectionPoint.connectPoint.SaveChanges();

            }
            catch 
            {

                throw;
            }
        }
    }
}
    