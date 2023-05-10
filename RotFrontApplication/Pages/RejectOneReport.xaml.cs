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
    /// Логика взаимодействия для RejectOneReport.xaml
    /// </summary>
    public partial class RejectOneReport : Page
    {
        public RejectOneReport(Reject reject)
        {
            InitializeComponent();
            TxbNumber.Text = reject.id.ToString();
            TxbNumberShip.Text = reject.Shipment_id.ToString();
            TxbReason.Text = reject.Reason.ToString();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

    }
}
