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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        private RequestForSending _request { get; set; }
        private Product _product { get; set; }

        public RequestPage(RequestForSending request)
        {
            InitializeComponent();

            _request = request;

            TxbNumber.Text = request.id.ToString();
            TxbProduct.Text = request.Product.Name.ToString();
            TxbNs.Text = request.Ns.Name;
            TxbCount.Text = request.Count.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = ConnectionPoint.connectPoint.RequestForSending.FirstOrDefault(x => x.id == _request.id);
                data.Status = 1;

                var dataWarehouse = ConnectionPoint.connectPoint.Product.FirstOrDefault(x => x.id == _request.id);
                dataWarehouse.Quantity_in_stock = CountProduct();
                ConnectionPoint.connectPoint.SaveChanges();

                MessageBox.Show("Статус закаа изменён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigateClass.frmNav.GoBack();

            }
            catch (Exception ex)
            {

            }
        }
        private double CountProduct()
        {
            var productCountOnWarehouse = ConnectionPoint.connectPoint.Product.FirstOrDefault(x => x.id == _request.id);
            var productCountOnShipment = ConnectionPoint.connectPoint.Shipment.FirstOrDefault(x => x.id == _request.id);

            return productCountOnWarehouse.Quantity_in_stock - productCountOnShipment.Count;

        }
    }
}

