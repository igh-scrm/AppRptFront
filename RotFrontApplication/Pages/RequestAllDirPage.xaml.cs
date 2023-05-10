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
    /// Логика взаимодействия для RequestAllDirPage.xaml
    /// </summary>
    public partial class RequestAllDirPage : Page
    {
        public RequestAllDirPage()
        {
            InitializeComponent();
            GridListRequestDir.ItemsSource = ConnectionPoint.connectPoint.RequestForSending.ToList();
            GridListRequestDir0.ItemsSource = ConnectionPoint.connectPoint.RequestForSending.Where(x=> x.Status == 0).ToList();


        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RequestPage((sender as Button).DataContext as RequestForSending));

        }

        private void BtnShip_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new ShipmentAllDirPage());
        }

        private void BtnViewAccept0_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RequestPage((sender as Button).DataContext as RequestForSending));

        }

        private void BtnPrintRequest_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListRequestDir, "Печать");
            }
        }

        private void BtnPrintRequest0_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListRequestDir0, "Печать");
            }
        }
    }
}
