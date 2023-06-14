using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
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

            var logHistory = ConnectionPoint.connectPoint.LogHistory.ToList();

            // Отобразить список пользователей и их историю входов в таблице DataGrid
            GridListUsers.ItemsSource = logHistory;

            // Проверить, есть ли пользователи с превышенным количеством ошибок при авторизации
            foreach (var item in logHistory.Where(x => x.CountBlockBtn != 0))
            {
                // Найти строку с данными о пользователе и выделить её цветом
                var row = (DataGridRow)GridListUsers.ItemContainerGenerator.ContainerFromItem(item);
                if (row != null)
                {
                    row.Background = new SolidColorBrush(Color.FromRgb(255, 127, 80));
                    row.Foreground = Brushes.White;
                }
            }

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new CreateUserPage());   

        }

        private void BtnBan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var idUser = (sender as Button).DataContext as User;
                MessageBoxResult result = MessageBox.Show("Вы подтверждаете блокировку пользователя?", "ERP: Складской учет", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var data = ConnectionPoint.connectPoint.Users.FirstOrDefault(x => x.id == idUser.UserId);
                    data.Status = 1;
                    ConnectionPoint.connectPoint.Users.AddOrUpdate(data);
                    ConnectionPoint.connectPoint.SaveChanges();

                    MessageBox.Show("Пользватель заблокирован!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigateClass.frmNav.GoBack();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}