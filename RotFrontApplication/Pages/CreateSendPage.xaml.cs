using RotFrontApplication.HelperClass;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CreateSendPage.xaml
    /// </summary>
    public partial class CreateSendPage : Page
    {
        public CreateSendPage()
        {
            InitializeComponent();

            CmdRequest_id.DisplayMemberPath = "id";
            CmdRequest_id.SelectedValuePath = "id";
            CmdRequest_id.ItemsSource = ConnectionPoint.connectPoint.RequestForSending.ToList();

            CmdUser_id.DisplayMemberPath = "Name";
            CmdUser_id.SelectedValuePath = "id";
            CmdUser_id.ItemsSource = ConnectionPoint.connectPoint.Users.Where(x => x.Role_id == 4).ToList();

            CmdAddress.DisplayMemberPath = "Address";
            CmdAddress.SelectedValuePath= "id";
            CmdAddress.ItemsSource = ConnectionPoint.connectPoint.Destination.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sending sending = new Sending();
                sending.Request_id = Convert.ToInt32(CmdRequest_id.SelectedValue);
                sending.User_id = Convert.ToInt32(CmdUser_id.SelectedValue);
                sending.Destination_id = Convert.ToInt32(CmdAddress.SelectedValue);
                sending.Date = DateTime.Now;
                sending.Status = 0;

                ConnectionPoint.connectPoint.Sending.AddOrUpdate(sending);
                ConnectionPoint.connectPoint.SaveChanges();
                MessageBox.Show("Данные добавлены!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}
