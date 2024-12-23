﻿using Receipt;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ReceiptClass> receipts = new List<ReceiptClass>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateRecept createRecept = new CreateRecept();
            createRecept.Owner = this;
            this.Hide();
            if(createRecept.ShowDialog() == true)
            {

                receipts.Add(createRecept.myReceipt);
            }
            this.Show();
        }
    }
}