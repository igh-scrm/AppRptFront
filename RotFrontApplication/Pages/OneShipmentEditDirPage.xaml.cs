using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для OneShipmentEditDirPage.xaml
    /// </summary>
    public partial class OneShipmentEditDirPage : Page
    {
        public OneShipmentEditDirPage(Shipment shipment)
        {
            InitializeComponent();
            TxbNumber0.Text = shipment.id.ToString();
            TxbFrom0.Text = shipment.Suppliers.CompanyName;
            TxbProduct0.Text = shipment.Warehouse.Product_id.ToString();
            TxbCount0.Text = shipment.Count.ToString();
            TxbNs0.Text = shipment.Ns.Name;
            TxbExpDate0.Text = shipment.ExpirationDate.ToString();


            CmbFrom.DisplayMemberPath = "CompanyName";
            CmbFrom.SelectedValuePath = "id";
            CmbFrom.ItemsSource = ConnectionPoint.connectPoint.Suppliers.ToList();

            CmbProduct.DisplayMemberPath = "Prodict_id";
            CmbProduct.SelectedValuePath = "id";
            CmbProduct.ItemsSource = ConnectionPoint.connectPoint.Warehouse.ToList();

            CmbNs.DisplayMemberPath = "Name";
            CmbNs.SelectedValuePath = "id";
            CmbNs.ItemsSource = ConnectionPoint.connectPoint.Ns.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Shipment shipment = new Shipment();
                shipment.Supplier_id = Convert.ToInt32(CmbFrom.SelectedValue);
                shipment.Warehouse_id = Convert.ToInt32(CmbProduct.SelectedValue);
                shipment.Ns_id = Convert.ToInt32(CmbNs.SelectedValue);
                shipment.Count = Convert.ToInt32(TxbCount.Text);
                shipment.ExpirationDate = Convert.ToDateTime(TxbExpDate.Text);

                ConnectionPoint.connectPoint.Shipment.AddOrUpdate(shipment);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Все кул!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}
