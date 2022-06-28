using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public abstract class User
    {
        private static int id = 1;
        public bool IsAdmin { get; set; }
        public User()
        {

        }
        protected User(string name, string lastName, string email, bool isAdmin)
        {
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.myId = id++;
            this.IsAdmin = isAdmin;
        }

        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int myId { get; set; }



        public override string ToString()
        {
            return name + ";" + lastName + ";" + email + ";";
        }
    }
}
