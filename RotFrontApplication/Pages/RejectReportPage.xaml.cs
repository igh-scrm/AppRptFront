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
    }
}
