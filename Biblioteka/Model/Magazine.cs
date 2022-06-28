using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    
    public class Magazine : Publication
    {


        public static readonly string TYPE = "Biblioteka.Magazine";

        

        public Magazine(string title, string author, int year, int month, string publisher, bool isBook) : base(title,publisher,year,isBook )
        {
            

            this.Month = month;
            this.Author = author;
            this.Type = TYPE;
            isBook = false;
        }
        public Magazine()
        {

        }



        public int Month { get; }
        public string Author { get; }
        public string Type { get; }

        public override string ToString()
        {
            return base.ToString() + ";" + Month + ";" + Author+ ";";
        }

    }
}
