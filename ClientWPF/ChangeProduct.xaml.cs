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

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для ChangeProduct.xaml
    /// </summary>
    public partial class ChangeProduct : Page
    {
        HttpClient client = new HttpClient();
        Product UpProduct;
        public ChangeProduct()
        {
            InitializeComponent();
        }
        public ChangeProduct(Product product)
        {
            InitializeComponent();
            UpProduct = product;
            TypeProducts.SelectedValuePath = "Id";
            TypeProducts.DisplayMemberPath = "Name";
            TypeProducts.ItemsSource = ProductDbContext.GetContext().TypeProducts.ToList();
            TypeProducts.SelectedIndex = (int)product.TypeProductId-1;
            DataContext = product;

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private async void Change_Button(object sender, RoutedEventArgs e)
        {

            var jsonProduct = JsonConvert.SerializeObject(UpProduct);
            HttpContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var respons = await client.PutAsync("https://localhost:7148/api/Product", content);
            Manager.MainFrame.Content = new ShowProducts();
        }
    }
}
