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
        private Product _product { get; set; }

        public ShipmentPage(Shipment shipment)
        {
            InitializeComponent();
            
            _shipment= shipment;
            CountProduct();

            TxbNumber.Text = shipment.id.ToString();
            TxbFrom.Text = shipment.Suppliers.CompanyName;
            TxbProduct.Text = shipment.Product.Name;
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

                var dataWarehouse = ConnectionPoint.connectPoint.Product.FirstOrDefault(x => x.id == _shipment.Product_id);
                dataWarehouse.Quantity_in_stock = CountProduct();
                ConnectionPoint.connectPoint.SaveChanges();

                MessageBox.Show("Статус закаа изменён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigateClass.frmNav.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   "Критическая работа приложения: " + ex.Message.ToLower(),
                   "Уведомление",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error
                   );
            }
        }

        private double CountProduct()
        {
            var productCountOnWarehouse = ConnectionPoint.connectPoint.Product.FirstOrDefault(x => x.id == _shipment.Product_id);
            var productCountOnShipment = ConnectionPoint.connectPoint.Shipment.FirstOrDefault(x => x.id == _shipment.id);

            return productCountOnShipment.Count + productCountOnWarehouse.Quantity_in_stock;
        }
    }
}
    