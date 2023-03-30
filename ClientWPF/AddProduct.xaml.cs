using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Text.Json;
namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        HttpClient client = new HttpClient();
        Product product = new Product();
        public AddProduct()
        {
            InitializeComponent();
            TypeProducts.SelectedValuePath = "Id";
            TypeProducts.DisplayMemberPath = "Name";
            TypeProducts.ItemsSource = ProductDbContext.GetContext().TypeProducts.ToList();
            
            
        }

       
        private void Back(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            product.Name = PName.Text;
            product.Price = decimal.Parse(PPrice.Text);
            product.TypeProductId = TypeProducts.SelectedIndex + 1;

            var jsonProduct = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync("https://localhost:7148/api/Product", content);
            Manager.MainFrame.Content = new ShowProducts();
        }
    }
}