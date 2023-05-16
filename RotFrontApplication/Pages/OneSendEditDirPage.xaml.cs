using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для OneSendEditDirPage.xaml
    /// </summary>
    public partial class OneSendEditDirPage : Page
    {
        public OneSendEditDirPage(Sending sending)
        {
            InitializeComponent();
            TxbId0.Text = sending.id.ToString();
            TxbId.Text = sending.id.ToString();
            TxbNumber0.Text = sending.Request_id.ToString();
            TxbUser0.Text = sending.Users.Name;
            TxbAddress0.Text = sending.Destination.Address;
            TxbNumber.Text = sending.Request_id.ToString();

            CmbUser.DisplayMemberPath = "Name";
            CmbUser.SelectedValuePath = "id";
            CmbUser.ItemsSource = ConnectionPoint.connectPoint.Users.Where(x => x.Role_id == 3).ToList();

            CmbAddress.DisplayMemberPath = "Address";
            CmbAddress.SelectedValuePath = "id";
            CmbAddress.ItemsSource = ConnectionPoint.connectPoint.Destination.ToList();
            

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sending sending = new Sending();
                sending.id = Convert.ToInt32(TxbId.Text);
                sending.Request_id = Convert.ToInt32(TxbNumber.Text);
                sending.User_id = Convert.ToInt32(CmbUser.SelectedValue);
                sending.Destination_id = Convert.ToInt32(CmbAddress.SelectedValue);

                ConnectionPoint.connectPoint.Sending.AddOrUpdate(sending);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Изменения внесены!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }
    }
}
