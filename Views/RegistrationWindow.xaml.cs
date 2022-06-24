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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод CheckData служит для проверки на корректность, введенных, в текстовые поля, данных.
        /// </summary>

        private static bool CheckData(TextBox nameTextBox, TextBox surnameTextBox, TextBox patronymicTextBox, TextBox loginTextBox, TextBox passwordTextBox)
       {
            bool result = true;
            if(string.IsNullOrEmpty(nameTextBox.Text) || 
               string.IsNullOrEmpty(surnameTextBox.Text) || 
               string.IsNullOrEmpty(patronymicTextBox.Text) || 
               string.IsNullOrEmpty(loginTextBox.Text) ||
               string.IsNullOrEmpty(passwordTextBox.Text))
            {
                result = false;
            }
            return result;
        }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!CheckData(nameTextBox, surnameTextBox, patronymicTextBox, loginTextBox, passwordTextBox))
                {
                    MessageBox.Show("Заполните корректно все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if(dbContext.User.FirstOrDefault(newUser => newUser.UserLogin == loginTextBox.Text) != null)
                {
                    MessageBox.Show("Такой пользователь уже есть", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    User user = new User()
                    {
                        UserName = nameTextBox.Text,
                        UserSurname = surnameTextBox.Text,
                        UserPatronymic = patronymicTextBox.Text,
                        UserLogin = loginTextBox.Text,
                        UserPassword = passwordTextBox.Text,
                        UserRole = 3
                    };
                    dbContext.User.Add(user);
                    dbContext.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались");
                    Close();
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
