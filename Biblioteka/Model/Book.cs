using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Book : Publication
    {
        public static readonly string TYPE = "Biblioteka.Book";
        private string author;
        private int isbn;
        private int pages;


        public Book(string title, string author, int isbn, int year, string publisher, int pages) : base (title, publisher, year)
        {
            this.isbn = isbn;
            this.author = author;
            this.Pages = pages;
        }


        public string Author { get => author; set => author = value; }
        public int Isbn { get => isbn; set => isbn = value; }
        public int Pages { get => pages; set => pages = value; }

        public override string ToString() 
        {
            return base.ToString() + "; " + author + "; "  +  isbn + "; " + pages + "; " ;
        }
    }
}
