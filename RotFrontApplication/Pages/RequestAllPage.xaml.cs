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
    /// Логика взаимодействия для RequestAllPage.xaml
    /// </summary>
    public partial class RequestAllPage : Page
    {
        public RequestAllPage()
        {
            InitializeComponent();
            GridListRequest.ItemsSource = ConnectionPoint.connectPoint.RequestForSending.Where(x=> x.Status == 0);

        }

        private void BtnViewAccept_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNav.Navigate(new RequestPage((sender as Button).DataContext as RequestForSending));

        }
    }
}
