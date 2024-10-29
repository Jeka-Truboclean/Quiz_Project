using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for CreateTestWindow.xaml
    /// </summary>
    public partial class CreateTestWindow : Window
    {
        public Test test { get; set; }
        public static List<Question> questions { get; set; }
        public CreateTestWindow()
        {
            questions = new List<Question>();

            InitializeComponent();
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {

        }
        //public class UserDataSource
        //{
        //    public IEnumerable<MyUser> Users { get; set; }

        //}

        //public class MyUser : INotifyPropertyChanged
        //{
        //    private int price;
        //    private string name;
        //    private int count;
        //    private readonly string image;

        //    public Product(string name, int price, int count, string source)
        //    {
        //        this.price = price;
        //        this.name = name;
        //        this.count = count;
        //        image = source;
        //    }


        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    public int Count
        //    {
        //        set
        //        {
        //            count = value;
        //            NotifyPropertyChanged();

        //        }
        //        get
        //        {
        //            return count;
        //        }
        //    }
        //    public bool IsActive { get; set; }
        //    public string Name
        //    {
        //        get
        //        {
        //            return name;
        //        }
        //        set
        //        {
        //            value = name;
        //        }
        //    }
        //    public string Image => image;

        //    public int Price => price;
        //    //public override string ToString()
        //    //{
        //    //    return"Name: "+Name+"\n"+"Price: "+Price+"\n"+"Count: "+Count;
        //    //}
        //}


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWindow addQuestionWindow = new AddQuestionWindow();
            addQuestionWindow.Show();
            listBox.Items.Add(addQuestionWindow.question.Text);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

            test = new Test() { Name = TitleTextBox.Text, Description = DescriptionTextBox.Text, Questions = questions };
        }
    }
}
