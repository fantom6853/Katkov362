using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class AnswerOptions
    {
        public AnswerOptions(string questiontext)
        {
            this.questiontext = questiontext;
        }
        public string questiontext { get; set; }
    }
}
