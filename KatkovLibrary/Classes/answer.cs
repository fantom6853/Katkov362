using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class Answer
    {
        public Answer(int id, int student, int quest, string answer)
        {
            this.id = id;
            this.student = student;
            this.quest = quest;
            this.answer = answer;
        }
        public int id { get; set; }
        public int student { get; set; }
        public int quest { get; set; }
        public string answer { get; set; }
    }
}