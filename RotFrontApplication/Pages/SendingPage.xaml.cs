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
    /// Логика взаимодействия для SendingPage.xaml
    /// </summary>
    public partial class SendingPage : Page
    {
        private Sending _sending { get; set; }
        public SendingPage(Sending sending)
        {
            InitializeComponent();
            _sending = sending;
            TxbNumber.Text = sending.id.ToString();
            TxbAddress.Text = sending.Destination.Address.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnSendEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = ConnectionPoint.connectPoint.Sending.FirstOrDefault(x=> x.id == _sending.id);
                data.Status = 1;
                ConnectionPoint.connectPoint.SaveChanges();

                MessageBox.Show("Статус закаа изменён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigateClass.frmNav.GoBack();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
