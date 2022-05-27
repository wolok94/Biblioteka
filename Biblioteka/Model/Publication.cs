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
        private string title;
        private string publisher;
        private int year;
        private static int id = 0;
        private int myId;
        




        public Publication(string title, string publisher, int year)
        {
            this.title = title;
            this.publisher = publisher;
            this.year = year;
            myId = id++;
        }

        public string Title { get => title; set => title = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Year { get => year; set => year = value; }

        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return title +  "; " + publisher + "; " + year;
        }

        public override bool Equals(object? obj)
        {
            return obj is Publication publication &&
                   title == publication.title &&
                   publisher == publication.publisher &&
                   year == publication.year &&
                   
                   myId == publication.myId &&
                   Title == publication.Title &&
                   Publisher == publication.Publisher &&
                   Year == publication.Year &&
                   
                   Id == publication.Id;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(title);
            hash.Add(publisher);
            hash.Add(year);
            
            hash.Add(myId);
            hash.Add(Title);
            hash.Add(Publisher);
            hash.Add(Year);
            
            hash.Add(Id);
            return hash.ToHashCode();
        }
    }
}
