using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class AnswerOptions
    {
        public AnswerOptions(string questiontext, string[] variants)
        {
            this.questiontext = questiontext;
            this.variants = variants;
        }
        public string questiontext { get; set; }
        public string[] variants { get; set; }
    }
}
