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
    /// Логика взаимодействия для CreateRequestPage.xaml
    /// </summary>
    public partial class CreateRequestPage : Page
    {
        public CreateRequestPage()
        {
            InitializeComponent();
            CmbNumberOfProduct.DisplayMemberPath = "Name";
            CmbNumberOfProduct.SelectedValuePath = "id";
            CmbNumberOfProduct.ItemsSource = ConnectionPoint.connectPoint.Product.ToList();

            CmbNs.DisplayMemberPath = "Name";
            CmbNs.SelectedValuePath = "id";
            CmbNs.ItemsSource = ConnectionPoint.connectPoint.Ns.ToList();

            CmbUserCollect.DisplayMemberPath = "SNP";
            CmbUserCollect.SelectedValuePath = "id";
            CmbUserCollect.ItemsSource = ConnectionPoint.connectPoint.Users.Where(x => x.Role_id == 2).ToList();


        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BntAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequestForSending request = new RequestForSending();
                request.Product_id = Convert.ToInt32(CmbNumberOfProduct.SelectedValue);
                request.Ns_id = Convert.ToInt32(CmbNs.SelectedValue);
                request.Count = Convert.ToInt32(TxbCount.Text);
                request.User_id = Convert.ToInt32(CmbUserCollect.SelectedValue);
                request.CollectUpTo = DateTime.Now;
                request.Status = 0;


                ConnectionPoint.connectPoint.RequestForSending.Add(request);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Данные добавлены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");

            }
        }
    }
}
