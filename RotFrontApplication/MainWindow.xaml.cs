using RotFrontApplication.HelperClass;
using RotFrontApplication.Pages;
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

namespace RotFrontApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateClass.frmNav = FrmMain;
            FrmMain.Navigate(new AuthPage());

            ConnectionPoint.connectPoint = new DbDauevaEntities1();
            
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

            if (NavigateClass.frmNav == null)
            {
                BtnExit.Visibility = Visibility.Visible;
            }
            else {
                BtnExit.Visibility = Visibility.Collapsed;
            }

            if (FrmMain.CanGoBack)
            {
                BtnExit.Visibility = Visibility.Visible;
            }
            else
            {
                BtnExit.Visibility = Visibility.Collapsed;
            }
        }
    }
}
