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
    /// Логика взаимодействия для SendingAllDirPage.xaml
    /// </summary>
    public partial class SendingAllDirPage : Page
    {
        public SendingAllDirPage()
        {
            InitializeComponent();
            GridListSendDir.ItemsSource = ConnectionPoint.connectPoint.Sending.Where(x => x.Status == 1).ToList();
            GridListSendDir0.ItemsSource = ConnectionPoint.connectPoint.Sending.Where(x=> x.Status ==0).ToList();


        }

        private void BtnShip_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new ShipmentAllDirPage());
        }

        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RequestAllDirPage());
        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneSendingDirPage((sender as Button).DataContext as Sending));

        }

        private void BtnViewAccept0_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneSendingDirPage((sender as Button).DataContext as Sending));

        }

        private void BtnPrintSend_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListSendDir, "Печать");
            }
        }

        private void BtnPrintSend0_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListSendDir0, "Печать");
            }
        }
    }
}
