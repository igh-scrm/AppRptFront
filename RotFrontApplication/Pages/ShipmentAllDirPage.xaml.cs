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
    /// Логика взаимодействия для ShipmentAllDirPage.xaml
    /// </summary>
    public partial class ShipmentAllDirPage : Page
    {
        public ShipmentAllDirPage()
        {
            InitializeComponent();
            GridListShipmentDir.ItemsSource = ConnectionPoint.connectPoint.Shipment.Where(x => x.Date == DateTime.Today).ToList();
            GridListShipmentDir0.ItemsSource = ConnectionPoint.connectPoint.Shipment.Where(x => x.Status == 0).ToList();


        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
        NavigateClass.frmNav.Navigate(new OneShipmentDirPage((sender as Button).DataContext as Shipment));

        }

        private void BtnViewAccept0_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneShipmentDirPage((sender as Button).DataContext as Shipment));

        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RejectReportPage());
        }

        private void BtnPrintShip_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListShipmentDir, "Печать");
            }
        }

        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RequestAllDirPage());
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new SendingAllDirPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridListShipmentDir.SelectedItems.Count > 0)
                {
                    var idUser = (sender as Button).DataContext as Shipment;
                    var item = ConnectionPoint.connectPoint.Shipment.Where(x => x.id == idUser.id).Single();
                    ConnectionPoint.connectPoint.Shipment.Remove(item);

                    ConnectionPoint.connectPoint.SaveChanges();
                    MessageBox.Show(
                        "Данные о заказе успешно удалены!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                        );
                    GridListShipmentDir.ItemsSource = ConnectionPoint.connectPoint.Shipment.ToList();
                }
                else
                {
                    MessageBox.Show(
                        "Данных в таблице нет!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Критическая работа приложения: " + ex.Message.ToLower(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneShipmentEditDirPage((sender as Button).DataContext as Shipment));
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneShipmentEditDirPage((sender as Button).DataContext as Shipment));

        }

        private void BtnCreateShip_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new CreateShipmentPage());
        }
    }
}
