﻿using RotFrontApplication.HelperClass;
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
    /// Логика взаимодействия для OneSendingDirPage.xaml
    /// </summary>
    public partial class OneSendingDirPage : Page
    {
        public OneSendingDirPage(Sending sending)
        {
            InitializeComponent();
            TxbNumber.Text = sending.id.ToString();
            TxbNumberRequest.Text = sending.Request_id.ToString();
            TxbResponsible.Text = sending.Users.SNP;
            TxbDate.Text = sending.Date.ToString();
            TxbAddress.Text = sending.Destination.Address.ToString();
            TxbStatus.Text = sending.Status.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }
    }
}
