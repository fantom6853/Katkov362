using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class Questionnaire
    {
        public Questionnaire(int id, int teacher,string name)
        {
            this.id = id;
            this.teacher = teacher;
            this.name = name;

        }
        public int id { get; set; }
        public int teacher { get; set; }
        public string name { get; set; }
    }
}
