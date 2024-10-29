using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for StudentMainWindow.xaml
    /// </summary>
    public partial class StudentMainWindow : Window
    {
        User user;
        private readonly ApplicationContext _context;
        public StudentMainWindow(User user)
        {
            this.user = user;
            InitializeComponent();
            _context = new ApplicationContext();
            userTextBox.Text += user.Login;

            LoadTests();
        }

        private void LoadTests()
        {
            // Получаем тесты из базы данных
            var tests = _context.Tests.ToList();

            // Привязываем список тестов к ItemsControl
            TestsItemsControl.ItemsSource = tests;
        }

        private void TakeTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                int testId = (int)button.Tag;

                // Загрузите тест вместе с вопросами и ответами
                var test = _context.Tests
                    .Include(t => t.Questions)
                        .ThenInclude(q => q.Answers)
                    .FirstOrDefault(t => t.Id == testId);

                if (test != null)
                {
                    // Открываем окно прохождения теста, передавая загруженный тест
                    var testTakingWindow = new TestTakingWindow(_context, test, user);
                    testTakingWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Test not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void MenuItem_Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To pass a test pess The Take Test Button ","Help",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
