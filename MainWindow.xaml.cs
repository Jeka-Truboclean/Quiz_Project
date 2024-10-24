using Quiz.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quiz.ApplicationContexts;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (var context = new ApplicationContext())
            {
                // Добовление чего либо в базу
            }


            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            EnterWindow enterWindow =new EnterWindow();
            enterWindow.ShowDialog();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow registerWindow=new RegisterWindow();
            registerWindow.Show();
        }
    }
}
