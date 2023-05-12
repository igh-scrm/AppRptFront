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
    /// Логика взаимодействия для OneRequestEditDir.xaml
    /// </summary>
    public partial class OneRequestEditDir : Page
    {
        public OneRequestEditDir(RequestForSending request)
        {
            InitializeComponent();
            TxbNumber0.Text = request.id.ToString();
            TxbNumber.Text = request.id.ToString();
            TxbProduct0.Text = request.Warehouse.id.ToString();
            TxbNs0.Text = request.Ns.Name;
            TxbCount0.Text = request.Count.ToString();
            TxbCollect0.Text = request.Users.Name.ToString();

            CmbProduct.DisplayMemberPath = "Product_id";
            CmbProduct.SelectedValuePath = "id";
            CmbProduct.ItemsSource = ConnectionPoint.connectPoint.Warehouse.ToList();

            CmbNs.DisplayMemberPath = "Name";
            CmbNs.SelectedValuePath = "id";
            CmbNs.ItemsSource = ConnectionPoint.connectPoint.Ns.ToList();

            CmbCollect.DisplayMemberPath = "Name";
            CmbCollect.SelectedValuePath = "id";
            CmbCollect.ItemsSource = ConnectionPoint.connectPoint.Users.Where(x => x.Role_id ==2).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequestForSending request = new RequestForSending();
                request.id = Convert.ToInt32(TxbNumber.Text);
                request.Warehouse_id = Convert.ToInt32(CmbProduct.SelectedValue);
                request.Ns_id = Convert.ToInt32(CmbNs.SelectedValue);
                request.Count = Convert.ToInt32(TxbCount.Text);
                request.User_id = Convert.ToInt32(CmbCollect.SelectedValue);    

                ConnectionPoint.connectPoint.RequestForSending.AddOrUpdate(request);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Все кул!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }
    }
}
