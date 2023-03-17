using Infrastructur.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        ObservableCollection<ProductDTO> ProductDTOs = new ObservableCollection<ProductDTO>();
        public MainWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = ProductDTOs;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var respons = await client.GetAsync("https://localhost:7148/api/Products/GetProducts");
            var products = await respons.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var product in products) 
            {
                ProductDTOs.Add(product);
            }
        }
    }
}
