﻿using System;
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
        public TeacherMainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To create a test press The Create Test Button", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
