using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Reader : User
    {
        private List <Publication> rentedPublications = new List <Publication> ();

        public Reader()
        {

        }

        public Reader(string name, string lastName, string email) : base(name, lastName, email)
        {
            
        }


        public void rentPublication (Publication publication)
        {
            rentedPublications.Add (publication);
            publication.isRented = true;
            DateTime now = DateTime.Today;
            publication.rentalDate = now;
            publication.deliveryDate = now.AddDays(30);
        }
        public void giveBackPublication (Publication publication)
        {
            rentedPublications.Remove (publication);
            publication.isRented= false;
            publication.rentalDate = DateTime.MinValue;
            publication.deliveryDate = DateTime.MinValue;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
