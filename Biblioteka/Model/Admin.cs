using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Admin : User
    {
        
        public string Password { get; set; }

        public Admin()
        {

        }
        public Admin(string name, string lastName, string email, string password, bool isAdmin) : base(name, lastName, email, isAdmin)
        {
            
            Password = password;
        }

        public override string ToString()
        {
            return base.ToString() + IsAdmin;
        }
    }
}
