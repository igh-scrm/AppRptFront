﻿using RotFrontApplication.HelperClass;
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
    /// Логика взаимодействия для CreateShipmentPage.xaml
    /// </summary>
    public partial class CreateShipmentPage : Page
    {
        public CreateShipmentPage()
        {
            InitializeComponent();
            CmbFrom.DisplayMemberPath = "CompanyName";
            CmbFrom.SelectedValuePath = "id";
            CmbFrom.ItemsSource = ConnectionPoint.connectPoint.Suppliers.ToList();

            CmbProduct.DisplayMemberPath = "Product_id";
            CmbProduct.SelectedValuePath = "id";
            CmbProduct.ItemsSource = ConnectionPoint.connectPoint.Warehouse.ToList();

            CmbNs.DisplayMemberPath = "Name";
            CmbNs.SelectedValuePath = "id";
            CmbNs.ItemsSource = ConnectionPoint.connectPoint.Ns.ToList();

            CmbUser.DisplayMemberPath = "Name";
            CmbUser.SelectedValuePath = "id";
            CmbUser.ItemsSource = ConnectionPoint.connectPoint.Users.Where(x => x.Role_id == 1);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Shipment shipment = new Shipment();
                shipment.Supplier_id = Convert.ToInt32(CmbFrom.SelectedValue);
                shipment.Warehouse_id = Convert.ToInt32(CmbProduct.SelectedValue);
                shipment.Ns_id = Convert.ToInt32(CmbNs.SelectedValue);
                shipment.Count = Convert.ToInt32(TxbCount.Text);
                shipment.ExpirationDate = DateTime.Now;

                ConnectionPoint.connectPoint.Shipment.AddOrUpdate(shipment);
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
