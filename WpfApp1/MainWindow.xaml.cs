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
        public MainWindow()
        {
            InitializeComponent();
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri("c:/soldatovVV/fruits.jpeg", UriKind.Relative);
            //image.EndInit();
            //imageBrush1.ImageSource = image;
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

            }
            this.Show();
        }
    }
}