using Quiz.ApplicationContexts;
using Quiz.Models;
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

namespace Quiz
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            RoleComboBox.Items.Add("student");
            RoleComboBox.Items.Add("teacher");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из текстовых полей
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            string role = RoleComboBox.SelectedItem?.ToString();

            // Проверка, что поля не пустые
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Сохранение пользователя в базу данных
            using (var context = new ApplicationContext())
            {
                // Проверяем, существует ли уже пользователь с таким логином
                var existingUser = context.Users.SingleOrDefault(u => u.Login == login);
                if (existingUser != null)
                {
                    MessageBox.Show("A user with this login already exists.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Создаем новый объект User
                var newUser = new User
                {
                    Login = login,
                    Password = password,
                    Role = role,
                    AttemptsLeft = 3
                };

                // Добавляем пользователя в базу
                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Закрытие окна регистрации или очистка полей
                this.Close();  // Закроем окно регистрации после успешной регистрации
            }
        }

        // Возврат на начальное меню
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
