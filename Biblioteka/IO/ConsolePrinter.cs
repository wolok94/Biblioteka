using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class ConsolePrinter
    {
        public void printText(string text)
        {
            Console.WriteLine(text);
        }
        public void printRentedPublications(User user)
        {
            if (user is Reader)
            {
                Reader reader = (Reader)user;
            
            foreach (Publication publication in reader.RentedPublications)
            {
                Console.WriteLine(publication.ToString());
            }
        }
        }
        public int choosePublicationToRent(SortedDictionary<int, Publication> dictionary)
        {
            foreach(Publication publication in dictionary.Values)
            {
                Console.WriteLine(publication.ToString());
            }
            Console.WriteLine("Wybierz pozycję do wypożyczenia po nr id");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        public void printBooks(SortedDictionary<int, Publication> dictionary)
        {

            var books = dictionary.Where(p => p.Value.GetType().ToString().Equals(Book.TYPE)).ToDictionary(p=> p.Key, p=> p.Value);
            foreach (Publication publication in books.Values)
            {
                
                printText(publication.ToString());
            }

        }
        public void printMagazine(SortedDictionary<int, Publication> dictionary)
        {

            var magazines = dictionary.Where(p => p.Value is Magazine).ToDictionary(p => p.Key, p=> p.Value);
            foreach (Publication publication in magazines.Values)
            {
                
            printText(publication.ToString());
            }
        }
        public void printUsers(SortedDictionary<int,User> users)
        {
            foreach(User user in users.Values)
            {
                Console.WriteLine(user.ToString());
            }
        }


    }
}
