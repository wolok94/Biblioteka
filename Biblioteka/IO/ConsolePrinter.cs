using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class ConsolePrinter
    {
        public void printText(string text)
        {
            Console.WriteLine(text);
        }
        public void printBooks(SortedDictionary<int, Publication> dic)
        {

            var a = dic.Where(p => p.Value.GetType().ToString().Equals(Book.TYPE)).ToDictionary(p=> p.Key, p=> p.Value);
            foreach (Publication publication in a.Values)
            {
                
                printText(publication.ToString());
            }

        }
        public void printMagazine(SortedDictionary<int, Publication> dic)
        {

            var a = dic.Where(p => p.Value is Magazine).ToDictionary(p => p.Key, p=> p.Value);
            foreach (Publication publication in a.Values)
            {
                
            printText(publication.ToString());
            }
        }


    }
}
