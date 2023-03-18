using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class Access
    {
        public Access(int id, int teacher, int student,int questionnaire)
        {
            this.id = id;
            this.teacher = teacher;
            this.student = student;
            this.questionnaire = questionnaire;
        }
        public int id { get; set; }
        public int teacher { get; set; }
        public int student { get; set; }
        public int questionnaire { get; set;}
    }
}
