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
        private string type;
        private string author;
        private int isbn;
        private int pages;
        

        


        public Book(string title, string author, int isbn, int year, string publisher, int pages, bool isBook) : base(title, publisher, year, isBook)
        {
            this.isbn = isbn;
            this.author = author;
            this.Pages = pages;
            this.type = TYPE;
            isBook = true;
        }
        public Book()
        {

        }


        public string Author { get => author; set => author = value; }
        public int Isbn { get => isbn; set => isbn = value; }
        public int Pages { get => pages; set => pages = value; }
        public string Type { get => type; set => type = value; }

        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   Title == book.Title &&
                   Publisher == book.Publisher &&
                   Year == book.Year &&
                   Type == book.Type &&
                   Id == book.Id &&
                   type == book.type &&
                   author == book.author &&
                   isbn == book.isbn &&
                   pages == book.pages &&
                   Author == book.Author &&
                   Isbn == book.Isbn &&
                   Pages == book.Pages &&
                   Type == book.Type;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Title);
            hash.Add(Publisher);
            hash.Add(Year);
            hash.Add(Type);
            hash.Add(Id);
            hash.Add(type);
            hash.Add(author);
            hash.Add(isbn);
            hash.Add(pages);
            hash.Add(Author);
            hash.Add(Isbn);
            hash.Add(Pages);
            hash.Add(Type);
            return hash.ToHashCode();
        }

        public override string ToString() 
        {
            return base.ToString() + "; " + author + "; "  +  isbn + "; " + pages + "; " ;
        }
    }
}
