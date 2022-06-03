using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.FileM
{
    interface UsersFileManager
    {
        public SortedDictionary<int, User> importUsers();
        public void exportUsers(Library library);
    }
}
