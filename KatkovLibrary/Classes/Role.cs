﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class Role
    {
        public Role(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}