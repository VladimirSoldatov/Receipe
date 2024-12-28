using Receipt;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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
    /// 



    public partial class MainWindow : Window
    {
        public ReceiptContaner receiptContaner = new ReceiptContaner();
        public MainWindow()
        {
            InitializeComponent();
             DataContext = receiptContaner.Receipts;
            listBoxOpen.ItemsSource = receiptContaner.Receipts;

        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("Components.json"))
                return;
            using (StreamReader sr = new StreamReader("Components.json"))
            {
                Stream stream = sr.BaseStream;
                

                    receiptContaner.Receipts = JsonSerializer.Deserialize<List<ReceiptClass>>(stream) ?? new List<ReceiptClass>();
           
                DataContext = receiptContaner.Receipts;
                listBoxOpen.ItemsSource = receiptContaner.Receipts;
            }
        }

        private void UnLoad(object sender, RoutedEventArgs e)
        {  
            
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

                receiptContaner.Receipts.Add(createRecept.myReceipt);
            }
            using (StreamWriter sw = new StreamWriter("Components.json"))
            {
                JsonSerializer.Serialize<List<ReceiptClass>>(sw.BaseStream, receiptContaner.Receipts);
                
            }
            listBoxOpen.Items.Refresh();
            this.Show();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (listBoxOpen.SelectedItem is not ReceiptClass)
            {
                MessageBox.Show("Рецепт не выбран!");
                return;
            }
            if (MessageBox.Show($"Удалить {listBoxOpen.SelectedItem}?", "Предупреждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                ReceiptClass temp = listBoxOpen.SelectedItem as ReceiptClass ?? new ReceiptClass();
                receiptContaner.Receipts.Remove(temp);
                listBoxOpen.Items.Refresh();
                using (StreamWriter sw = new StreamWriter("Components.json"))
                {
                    JsonSerializer.Serialize<List<ReceiptClass>>(sw.BaseStream, receiptContaner.Receipts);


                }
            }
        }
    }
}