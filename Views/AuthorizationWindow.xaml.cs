using FabricsShop.AppData;
using System.Linq;
using System.Windows;

namespace FabricsShop.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(loginTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text))
            {
                using (DBContext dbContext = new DBContext())
                {
                    User authUser = dbContext.User.FirstOrDefault(newUser => newUser.UserLogin == loginTextBox.Text ||
                                                                  newUser.UserPassword == passwordTextBox.Text);
                    if (authUser != null)
                    {
                        StartWindow.currentUser = authUser;
                        MessageBox.Show("Вы авторизовались");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните корректно все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
