using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class Quest
    {
        public Quest(int id, int questionaire, int type,string text,string answeroptions)
        {
            this.id = id;
            this.questionaire = questionaire;
            this.type = type;
            this.text = text;
            this.answeroptions = answeroptions;
        }
        public int id { get; set; }
        public int questionaire { get; set; }
        public int type { get; set; }
        public string text { get; set; }
        public string answeroptions { get; set; }
    }
}
