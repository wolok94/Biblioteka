using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Reader : User
    {

        public Reader()
        {
            
        }

        public Reader(string name, string lastName, string email, bool isAdmin) : base(name, lastName, email, isAdmin)
        {
              
        }
        private List<Publication> rentedPublications = new List<Publication>();

        public List<Publication> RentedPublications { get => rentedPublications; set => rentedPublications = value; }


        string rentedPublicationsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Publication publication in RentedPublications)
            {
                if (publication.IsBook)
                {
                    Book book = (Book) publication;
                    sb.Append(Book.TYPE + ";" + book.ToString());
                }else 
                {
                    Magazine magazine = (Magazine) publication;
                    sb.Append(Magazine.TYPE + ";" + magazine.ToString());
                }
            }
            return sb.ToString();
        }
        public void rentPublication (Publication publication)
        {
            RentedPublications.Add (publication);
            publication.isRented = true;
            DateTime now = DateTime.Today;
            publication.rentalDate = now;
            publication.deliveryDate = now.AddDays(30);
        }
        public void giveBackPublication (Publication publication)
        {
            RentedPublications.Remove (publication);
            publication.isRented= false;
            publication.rentalDate = DateTime.MinValue;
            publication.deliveryDate = DateTime.MinValue;
        }
        public override string ToString()
        {
            return base.ToString() + IsAdmin + ";/" + rentedPublicationsToString();
        }
    }
}
