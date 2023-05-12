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
    /// Логика взаимодействия для RejectReportPage.xaml
    /// </summary>
    public partial class RejectReportPage : Page
    {
        public RejectReportPage()
        {
            InitializeComponent();
            GridListReject.ItemsSource = ConnectionPoint.connectPoint.Reject.ToList();

        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RejectOneReport((sender as Button).DataContext as Reject));

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnPrintRejectReport_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(GridListReject, "Печать");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridListReject.SelectedItems.Count > 0)
                {
                    var idUser = (sender as Button).DataContext as Reject;
                    var item = ConnectionPoint.connectPoint.Reject.Where(x => x.id == idUser.id).Single();
                    ConnectionPoint.connectPoint.Reject.Remove(item);

                    ConnectionPoint.connectPoint.SaveChanges();
                    MessageBox.Show(
                        "Данные о заказе успешно удалены!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                        );
                    GridListReject.ItemsSource = ConnectionPoint.connectPoint.Reject.ToList();
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
            NavigateClass.frmNav.Navigate(new OneRejectEditDirPage((sender as Button).DataContext as Reject));
        }
    }
}
