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
                request.Warehouse_id = 1;
                request.Ns_id = 1;
                request.Count = 1;
                request.CollectUpTo = DateTime.Now;
                request.Status = 0;

                ConnectionPoint.connectPoint.RequestForSending.Add(request);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Все кул!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");

            }
        }
    }
}
