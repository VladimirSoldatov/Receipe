using Receipt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CreateRecept.xaml
    /// </summary>
    public partial class CreateRecept : Window
    {
        public CreateRecept()
        {
            InitializeComponent();
        }
        LoadResources loadResources;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadResources loadResources = new LoadResources("components.txt");
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            loadResources = new LoadResources("C:\\Users\\vvsoldatov\\source\\repos\\WpfApp1\\WpfApp1\\Components.txt");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Components> arrayList = loadResources.GetComponents();
            if (arrayList != null)
            {
                string[]  names =  arrayList.Select(p => p.Name).ToArray();
                label1.Content += String.Join(",", names);
  
            }
        
       
                    
        }
    }
}
