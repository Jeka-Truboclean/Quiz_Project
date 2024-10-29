using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Net.Mime.MediaTypeNames;
using User = Quiz.Models.User;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for TestTakingWindow.xaml
    /// </summary>
    public partial class TestTakingWindow : Window
    {
        private readonly ApplicationContext _context;
        private readonly Test _test;
        private readonly User _user;
        private readonly Dictionary<int, List<int>> _selectedAnswers;
        public TestTakingWindow(ApplicationContext context, Test test, User user)
        {
            InitializeComponent();
            _context = context;
            _test = test;
            _user = user;
            _selectedAnswers = new Dictionary<int, List<int>>();

            LoadTest();
        }

        private void LoadTest()
        {
            TestNameTextBlock.Text = _test.Name;

            foreach (var question in _test.Questions)
            {
                var questionPanel = new StackPanel { Margin = new Thickness(0, 10, 0, 20) };

                // Отображаем текст вопроса
                var questionTextBlock = new TextBlock
                {
                    Text = question.Text,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                questionPanel.Children.Add(questionTextBlock);

                // Создаем элементы для выбора ответов в зависимости от типа вопроса
                if (question.QuestionType == "Single Answer")
                {
                    //var answerGroup = new RadioButtonGroup();
                    foreach (var answer in question.Answers)
                    {
                        var radioButton = new RadioButton
                        {
                            Content = answer.Text,
                            Tag = answer.Id,
                            Margin = new Thickness(0, 2, 0, 2)
                        };
                        radioButton.Checked += AnswerSelected;
                        questionPanel.Children.Add(radioButton);
                    }
                }
                else if (question.QuestionType == "Multiple Answers")
                {
                    foreach (var answer in question.Answers)
                    {
                        var checkBox = new CheckBox
                        {
                            Content = answer.Text,
                            Tag = answer.Id,
                            Margin = new Thickness(0, 2, 0, 2)
                        };
                        checkBox.Checked += AnswerSelected;
                        checkBox.Unchecked += AnswerUnselected;
                        questionPanel.Children.Add(checkBox);
                    }
                }

                QuestionsStackPanel.Children.Add(questionPanel);
            }
        }

        private void AnswerSelected(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            var answerId = (int)control.Tag;
            var questionId = _test.Questions.First(q => q.Answers.Any(a => a.Id == answerId)).Id;

            if (!_selectedAnswers.ContainsKey(questionId))
            {
                _selectedAnswers[questionId] = new List<int>();
            }

            if (!_selectedAnswers[questionId].Contains(answerId))
            {
                _selectedAnswers[questionId].Add(answerId);
            }
        }

        private void AnswerUnselected(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            var answerId = (int)control.Tag;
            var questionId = _test.Questions.First(q => q.Answers.Any(a => a.Id == answerId)).Id;

            _selectedAnswers[questionId]?.Remove(answerId);
        }

        private void SubmitTestButton_Click(object sender, RoutedEventArgs e)
        {
            int correctAnswersCount = 0;
            int totalQuestions = _test.Questions.Count;

            foreach (var question in _test.Questions)
            {
                var correctAnswerIds = question.Answers.Where(a => a.IsCorrect).Select(a => a.Id).ToList();

                if (_selectedAnswers.ContainsKey(question.Id) && _selectedAnswers[question.Id].SequenceEqual(correctAnswerIds))
                {
                    correctAnswersCount++;
                }
            }

            // Подсчет процента правильных ответов
            double scorePercentage = ((double)correctAnswersCount / totalQuestions) * 100;
            MessageBox.Show($"You scored: {scorePercentage}%", "Test Result");

            // Сохранение результата(дорабатывую)
            var result = new Result
            {
                
            };

            _context.Results.Add(result);
            _context.SaveChanges();

            Close();
        }
    }
}
