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
        private int month;
        private string author;
        private string type;
        

        public Magazine(string title, string author, int year, int month, string publisher, bool isBook) : base(title,publisher,year,isBook )
        {
            

            this.month = month;
            this.author = author;
            this.type = TYPE;
            isBook = false;
        }
        public Magazine()
        {

        }



        public int Month { get => month; set => month = value; }
        public string Author { get => author; set => author = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return base.ToString() + "; " + month + "; " + author+ "; ";
        }
    }
}
