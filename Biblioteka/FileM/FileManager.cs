using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.FileM
{
    interface FileManager
    {
        SortedDictionary<int,Publication> importData();
        void exportData(Library library);
    }
}
