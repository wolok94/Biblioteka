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
        private string publisher;
        private string type;
        

        public Magazine(string title, string author, int year, int month, string publisher, bool isBook) : base(title,author,year,isBook )
        {
            

            this.month = month;
            Publisher = publisher;
            this.type = TYPE;
            isBook = false;
        }
        public Magazine()
        {

        }



        public int Month { get => month; set => month = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return base.ToString() + "; " + month + "; " + Publisher+ "; ";
        }
    }
}
