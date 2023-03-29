using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для ShowProducts.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        HttpClient client = new HttpClient();
        ObservableCollection<Product> Products = new ObservableCollection<Product>();
        public ShowProducts()
        {
            InitializeComponent();
            Show();

        }

        private async Task Show()
        {
            var respons = await client.GetAsync("https://localhost:7148/api/Product/GetProducts");
            var products = await respons.Content.ReadAsAsync<List<Product>>();

            foreach (var product in products)
            {
                Products.Add(product);
            }
            ListProduct.ItemsSource = Products;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Product SelectProduct = (sender as Button).DataContext as Product;
            Manager.MainFrame.Content = new ChangeProduct(SelectProduct);

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердить удаление", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Product SelectProduct = (sender as Button).DataContext as Product;
                var respons = await client.DeleteAsync($"https://localhost:7148/api/Product/DeleteProduct?id={SelectProduct.Id}");
                Manager.MainFrame.Content = new ShowProducts();
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProduct());
        }
    }
}
