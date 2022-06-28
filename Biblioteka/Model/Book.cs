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

        public Book(string title, string author, int isbn, int year, string publisher, int pages, bool isBook) : base(title, publisher, year, isBook)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Pages = pages;
            this.Type = TYPE;
            isBook = true;
        }
        public Book()
        {

        }


        public string Author { get; }
        public int Isbn { get; }
        public int Pages { get; }
        public string Type { get; }

        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   Title == book.Title &&
                   Publisher == book.Publisher &&
                   Year == book.Year &&
                   Type == book.Type &&
                   Id == book.Id &&
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
            hash.Add(Author);
            hash.Add(Isbn);
            hash.Add(Pages);
            hash.Add(Type);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + ";" + Author + ";" + Isbn + ";" + Pages + ";";
        }


    }
}
