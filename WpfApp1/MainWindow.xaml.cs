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
        List<ReceiptClass> receipts = new List<ReceiptClass>();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("Components.json"))
                return;
            using (StreamReader sw = new StreamReader("Components.json"))
            {
                    if (sw.BaseStream is null)
                        return;
                receipts = JsonSerializer.Deserialize<List<ReceiptClass>>(sw.BaseStream)??new List<ReceiptClass>();

            }
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
            using (StreamWriter sw = new StreamWriter("Components.json"))
            {
                JsonSerializer.Serialize<List<ReceiptClass>>(sw.BaseStream, receipts);
                
            }
            this.Show();
        }
    }
}