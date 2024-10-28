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

                //// Создаем тесты
                //var biologyTest = new Test
                //{
                //    Name = "Biology",
                //    Description = "Basic Biology Concepts",
                //    Questions = new List<Question>()
                //};

                //var geographyTest = new Test
                //{
                //    Name = "Geography",
                //    Description = "Basic Geography Concepts",
                //    Questions = new List<Question>()
                //};

                //// Добавляем тесты в контекст
                //context.Tests.AddRange(biologyTest, geographyTest);

                //// Добавляем вопросы и ответы для Biology Test
                //var bioQuestion1 = new Question
                //{
                //    Text = "What is the main source of energy for plants?",
                //    QuestionType = "Single answer",
                //    Weight = 2,
                //    Test = biologyTest,
                //    Answers = new List<Answer>
                //    {
                //        new Answer { Text = "Sunlight", IsCorrect = true },
                //        new Answer { Text = "Water", IsCorrect = false },
                //        new Answer { Text = "Soil", IsCorrect = false }
                //    }
                //};

                //var bioQuestion2 = new Question
                //{
                //    Text = "Which of the following are mammals?",
                //    QuestionType = "Multiple answers",
                //    Weight = 3,
                //    Test = biologyTest,
                //    Answers = new List<Answer>
                //    {
                //        new Answer { Text = "Dog", IsCorrect = true },
                //        new Answer { Text = "Chicken", IsCorrect = false },
                //        new Answer { Text = "Whale", IsCorrect = true }
                //    }
                //};

                //// Добавляем вопросы и ответы для Geography Test
                //var geoQuestion1 = new Question
                //{
                //    Text = "What is the longest river in the world?",
                //    QuestionType = "Single answer",
                //    Weight = 2,
                //    Test = geographyTest,
                //    Answers = new List<Answer>
                //    {
                //        new Answer { Text = "Amazon", IsCorrect = true },
                //        new Answer { Text = "Nile", IsCorrect = false },
                //        new Answer { Text = "Mississippi", IsCorrect = false }
                //    }
                //};

                //var geoQuestion2 = new Question
                //{
                //    Text = "Which of the following countries are in South America?",
                //    QuestionType = "Multiple answers",
                //    Weight = 3,
                //    Test = geographyTest,
                //    Answers = new List<Answer>
                //    {
                //        new Answer { Text = "Brazil", IsCorrect = true },
                //        new Answer { Text = "France", IsCorrect = false },
                //        new Answer { Text = "Argentina", IsCorrect = true }
                //    }
                //};

                //// Добавляем вопросы к тестам
                //biologyTest.Questions.Add(bioQuestion1);
                //biologyTest.Questions.Add(bioQuestion2);
                //geographyTest.Questions.Add(geoQuestion1);
                //geographyTest.Questions.Add(geoQuestion2);

                //// Сохраняем все изменения в базе данных
                //context.SaveChanges();

                //Console.WriteLine("Database initialized with tests, questions, and answers.");
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
            registerWindow.ShowDialog();
        }
    }
}
