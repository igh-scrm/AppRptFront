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
    /// Логика взаимодействия для ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        public ShipmentPage(Shipment shipment)
        {
            InitializeComponent();

            TxbNumber.Text = shipment.id.ToString();
            TxbFrom.Text = shipment.Suppliers.CompanyName;
            TxbProduct.Text = shipment.Warehouse.Product_id.ToString();
            TxbCount.Text = shipment.Count.ToString();
            TxbNs.Text = shipment.Ns.Name;
            TxbExpDate.Text = shipment.ExpirationDate.ToString();
            TxbStatus.Text = shipment.Status.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}
    