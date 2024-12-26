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
using System.Windows.Shapes;

namespace Receipt
{
    /// <summary>
    /// Логика взаимодействия для SearchReceipt.xaml
    /// </summary>
    public partial class SearchReceipt : Window
    {
        public List<ReceiptClass> Receipts { get; set; } = new List<ReceiptClass>();
        public SearchReceipt()
        {
            InitializeComponent();
            
        }
    }
}
