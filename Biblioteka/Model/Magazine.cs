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
        private string title;
        private string author;
        private int year;
        private int month;
        private string publisher;
        public static readonly string TYPE = "Biblioteka.Magazine";

        public Magazine(string title, string author, int year, int month, string publisher) : base(title,author,year)
        {
            

            this.month = month;
            this.publisher = publisher;
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int Month { get => month; set => month = value; }
        public string Publisher { get => publisher; set => publisher = value; }

        public override string ToString()
        {
            return base.ToString() + "; " + month + "; " + publisher+ "; ";
        }
    }
}
