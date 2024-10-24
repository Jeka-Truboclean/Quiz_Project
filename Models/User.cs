using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "ученик" или "преподаватель"
        public int AttemptsLeft { get; set; } // Количество попыток
        public ICollection<Result> Results { get; set; }
    }

}
