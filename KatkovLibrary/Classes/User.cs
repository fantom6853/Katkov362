using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatkovLibrary.Classes
{
    public class User
    {
        public User(int id, string login,string password,string name,string surname,string patronimic,int role,int groups)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.patronimic= patronimic;
            
            this.role = role;
            if (groups > 0)
            {
                this.groups = groups;
            }
        }
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronimic { get; set; }
        public int role { get; set; }
        public int groups { get; set; }
    }
}
