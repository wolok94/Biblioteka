using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.FileM
{
    interface FileManager
    {
        Library importData();
        void exportData(Library library);
    }
}
