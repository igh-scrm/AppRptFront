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
    /// Логика взаимодействия для RejectPage.xaml
    /// </summary>
    public partial class RejectPage : Page
    {
        public RejectPage()
        {
            InitializeComponent();
            CmbNumberOfShipment.DisplayMemberPath = "id";
            CmbNumberOfShipment.SelectedValuePath = "id";
            CmbNumberOfShipment.ItemsSource = ConnectionPoint.connectPoint.Shipment.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BntSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reject reject = new Reject();
                reject.Shipment_id = Convert.ToInt32(CmbNumberOfShipment.SelectedValue);
                reject.Reason = TxbReason.Text;

                ConnectionPoint.connectPoint.Reject.Add(reject);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Отчет отправлен!");


            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }
    }
}
