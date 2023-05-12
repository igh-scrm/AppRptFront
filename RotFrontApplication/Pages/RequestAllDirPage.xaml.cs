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
            NavigateClass.frmNav.Navigate(new OneRequestDirPage((sender as Button).DataContext as RequestForSending));

        }

        private void BtnShip_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new ShipmentAllDirPage());
        }

        private void BtnViewAccept0_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new OneRequestDirPage((sender as Button).DataContext as RequestForSending));

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

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new SendingAllDirPage());
        }

        private void BtnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new CreateRequestPage());
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RejectReportPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridListRequestDir.SelectedItems.Count > 0)
                {
                    var idUser = (sender as Button).DataContext as RequestForSending;
                    var item = ConnectionPoint.connectPoint.RequestForSending.Where(x => x.id == idUser.id).Single();
                    ConnectionPoint.connectPoint.RequestForSending.Remove(item);

                    ConnectionPoint.connectPoint.SaveChanges();
                    MessageBox.Show(
                        "Данные о заказе успешно удалены!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                        );
                    GridListRequestDir.ItemsSource = ConnectionPoint.connectPoint.RequestForSending.ToList();
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
            NavigateClass.frmNav.Navigate(new OneRequestEditDir((sender as Button).DataContext as RequestForSending));
        }
    }
}