using Microsoft.Win32;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for AddQuestionWindow.xaml
    /// </summary>
    public partial class AddQuestionWindow : Window
    {
        public Question question { get; set; }
        public AddQuestionWindow()
        {
            InitializeComponent();
        }


        private void EnterButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<Answer> answers = new List<Answer>();
            int i = 1;
            foreach (var a in listBox1.Items)
            {
                if (i == Convert.ToInt32(TrueTextBox.Text))
                {
                    answers.Add(new Answer() { Text = a.ToString(), IsCorrect = true });

                }
                else
                {
                    answers.Add(new Answer() { Text = a.ToString(), IsCorrect = false });

                }
                i++;
            }

            question = new Question() { Text = QuestionTextBox.Text, Answers = answers };
            this.Close();
            CreateTestWindow testWindow = new CreateTestWindow();
            CreateTestWindow.questions.Add(question);
            testWindow.Show();
        }


        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add(AnswerTextBox.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                pathTextBox.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
        }

    }
}
