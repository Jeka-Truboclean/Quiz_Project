using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string QuestionType { get; set; } // "Один ответ" или "Несколько ответов"
        public int Weight { get; set; }
        public byte[] Image { get; set; } // Изображение в формате байтового массива
        public int TestId { get; set; }
        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }

}
