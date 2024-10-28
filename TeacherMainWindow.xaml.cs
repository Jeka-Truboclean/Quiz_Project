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
    /// Interaction logic for TeacherMainWindow.xaml
    /// </summary>
    public partial class TeacherMainWindow : Window
    {
        User user;
        public TeacherMainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            userTextBox.Text = user.Login;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To create a test press The Create Test Button", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CreateTestWindow testWindow = new CreateTestWindow();
            testWindow.Show();
        }
    }
}
