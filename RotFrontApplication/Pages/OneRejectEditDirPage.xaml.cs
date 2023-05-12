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
    /// Логика взаимодействия для OneRejectEditDirPage.xaml
    /// </summary>
    public partial class OneRejectEditDirPage : Page
    {
        public OneRejectEditDirPage(Reject reject)
        {
            InitializeComponent();
            TxbNumber0.Text = reject.id.ToString();
            TxbNumber.Text = reject.id.ToString();
            TxbNumberShipment.Text = reject.Shipment_id.ToString();
            TxbRason0.Text = reject.Reason.ToString();

            CmdNumberShipment.DisplayMemberPath = "id";
            CmdNumberShipment.SelectedValuePath = "id";
            CmdNumberShipment.ItemsSource = ConnectionPoint.connectPoint.Shipment.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reject reject = new Reject();
                reject.id = Convert.ToInt32(TxbNumber.Text);
                reject.Shipment_id = Convert.ToInt32(CmdNumberShipment.SelectedValue);
                reject.Reason = TxbReason.Text;

                ConnectionPoint.connectPoint.Reject.AddOrUpdate(reject);
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
