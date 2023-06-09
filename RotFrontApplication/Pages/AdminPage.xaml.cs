using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            GridListUsers.ItemsSource = ConnectionPoint.connectPoint.LogHistory.ToList();

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new CreateUserPage());   
        }
    }
}