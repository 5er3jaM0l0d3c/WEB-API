using Entities;
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
        public MainWindow()
        {
            InitializeComponent();
      
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new ShowProducts());

        }

        private void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ShowProducts());
        }

        private void ChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ChangeProduct());
        }
    }
}
