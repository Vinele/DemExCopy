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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public static User currentUser;
        public StartWindow()
        {
            InitializeComponent();
            currentUser = new User();
            usernameLabel.Content = "Ваш статус: Гость";
        }

        private void productsListButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.ShowDialog();
            Show();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
            Show();

         
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.ShowDialog();
            usernameLabel.Content = $"{currentUser.UserSurname} {currentUser.UserName} {currentUser.UserPatronymic}";
            Show();        
        }
    }
}
