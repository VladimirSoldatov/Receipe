using Receipt;
using System.IO;
using System.Text;
using System.Text.Json;
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
        public ReceiptContaner receiptContaner = new ReceiptContaner();
        public MainWindow()
        {
            InitializeComponent();
             DataContext = receiptContaner.Receipts;

        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("Components.json"))
                return;
            using (StreamReader sw = new StreamReader("Components.json"))
            {
                    if (sw.BaseStream is not null)
                   receiptContaner.Receipts = JsonSerializer.Deserialize<List<ReceiptClass>>(sw.BaseStream)??new List<ReceiptClass>();

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchReceipt searchReceipt = new SearchReceipt() {DataContext = receiptContaner.GetNames};
            searchReceipt.Owner = this;

            if (searchReceipt.ShowDialog() == true)
            {

          
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateRecept createRecept = new CreateRecept();
            createRecept.Owner = this;
            this.Hide();
            if(createRecept.ShowDialog() == true)
            {

                receiptContaner.Receipts.Add(createRecept.myReceipt);
            }
            using (StreamWriter sw = new StreamWriter("Components.json"))
            {
                JsonSerializer.Serialize<List<ReceiptClass>>(sw.BaseStream, receiptContaner.Receipts);
                
            }
            this.Show();
        }
    }
}