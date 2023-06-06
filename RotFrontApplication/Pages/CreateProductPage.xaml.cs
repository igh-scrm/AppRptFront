using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Authentication;
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
    /// Логика взаимодействия для CreateProductPage.xaml
    /// </summary>
    public partial class CreateProductPage : Page
    {
        public CreateProductPage()
        {
            InitializeComponent();

            CmbType.DisplayMemberPath = "Name";
            CmbType.SelectedValuePath = "id";
            CmbType.ItemsSource = ConnectionPoint.connectPoint.Type.ToList();

            CmbNs.DisplayMemberPath = "Name";
            CmbNs.SelectedValuePath = "id";
            CmbNs.ItemsSource = ConnectionPoint.connectPoint.Ns.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Product product = new Product();
                product.Type_id = Convert.ToInt32(CmbType.SelectedValue);
                product.Name = TxbName.Text;
                product.Quantity_in_stock = 0;
                product.Ns_id = Convert.ToInt32(CmbNs.SelectedValue);
                ConnectionPoint.connectPoint.Product.Add(product);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Продукт добавлен!");




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
