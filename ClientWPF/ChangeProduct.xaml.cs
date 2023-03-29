using Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для ChangeProduct.xaml
    /// </summary>
    public partial class ChangeProduct : Page
    {
        public ChangeProduct()
        {
            InitializeComponent();
        }
        public ChangeProduct(Product product)
        {
            InitializeComponent();
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
    }
}
