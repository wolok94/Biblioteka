using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Biblioteka.Model
{
    
    public abstract class Publication 
    {

        private static int id = 0;

 public Publication(string title, string publisher, int year, bool isBook)
        {
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            MyId = id + 1;
            this.IsBook = isBook;
        }
        public Publication()
        {

        }

        public string Title { get; }
        public string Publisher { get; }
        public int Year { get; }

        public int Id { get; }
        public bool IsBook { get; }
        public bool isRented { get; set; }
        public DateTime rentalDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int MyId { get; private set; }

        public void setId(int id)
        {
            MyId = id;
        }
        public override string ToString()
        {
            return MyId + ";" + Title + ";" + Publisher + ";" + Year;
        }

        public override bool Equals(object? obj)
        {
            return obj is Publication publication &&

                   MyId == publication.MyId &&
                   Title == publication.Title &&
                   Publisher == publication.Publisher &&
                   Year == publication.Year &&
                   
                   Id == publication.Id;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(MyId);
            hash.Add(Title);
            hash.Add(Publisher);
            hash.Add(Year);
            
            hash.Add(Id);
            return hash.ToHashCode();
        }
    }
}
