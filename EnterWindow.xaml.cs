using Quiz.ApplicationContexts;
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
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        public EnterWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из полей
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            // Проверка, что поля не пустые
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your login and password.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка пользователя через базу данных
            using (var context = new ApplicationContext())
            {
                // Проверяем, существует ли пользователь с такими логином и паролем
                var user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    // Пользователь найден
                    MessageBox.Show($"Welcome, {user.Login}!", "Seccess", MessageBoxButton.OK, MessageBoxImage.Information);
                    //this.DialogResult = true;  // Можно использовать, если окно вызвано как диалоговое
                    this.Close();  
                    if (user.Role == "teacher")
                    {
                        TeacherMainWindow teacherWindow=new TeacherMainWindow(user);
                        teacherWindow.Show();
                    }
                    else
                    {
                        StudentMainWindow studentWindow = new StudentMainWindow(user);
                        studentWindow.Show();
                    }
                }
                else
                {
                    // Пользователь не найден
                    MessageBox.Show("This user does not exist or incorrect data has been entered.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
