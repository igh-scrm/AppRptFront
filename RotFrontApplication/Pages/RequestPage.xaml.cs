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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage(RequestForSending request)
        {
            InitializeComponent();
            TxbNumber.Text = request.id.ToString();
            TxbProduct.Text = request.Warehouse.id.ToString();
            TxbNs.Text = request.Ns.Name;
            TxbCount.Text = request.Count.ToString();
            TxbStatus.Text = request.Status.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.GoBack();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
