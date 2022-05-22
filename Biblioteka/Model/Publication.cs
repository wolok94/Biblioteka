using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public abstract class Publication : IEnumerable<Publication>
    {
        private string title;
        private string publisher;
        private int year;



        protected Publication(string title, string publisher, int year)
        {
            this.title = title;
            this.publisher = publisher;
            this.year = year;
        }

        public string Title { get => title; set => title = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Year { get => year; set => year = value; }

        public IEnumerator<Publication> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return title +  "; " + publisher + "; " + year;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
