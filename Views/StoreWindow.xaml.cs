using FabricsShop.AppData;
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
using System.Windows.Shapes;

namespace FabricsShop.Views
{
    /// <summary>
    /// Логика взаимодействия для StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        public StoreWindow()
        {
            InitializeComponent();
        }

        private static List<Product> RefreshData()
        {
            using(DBContext dbContext = new DBContext())
            {
                return dbContext.Product.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridProduct.ItemsSource = RefreshData();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
