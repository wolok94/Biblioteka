using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Exception;

namespace Biblioteka
{
    [Serializable]
    public class Library
    {

        private SortedDictionary<int, Publication> publications = new SortedDictionary<int, Publication>();
        private SortedDictionary<int, User> users = new SortedDictionary<int, User>();

        public SortedDictionary<int, Publication> Publications { get; set; }
        public SortedDictionary<int, User> Users { get; set; }
        public ConsolePrinter printer = new ConsolePrinter();

        public void addPublication(Publication publication)
        {
            if (publications != null)
            {
                if (publications.ContainsKey(publication.MyId))
                {
                    throw new PublicationAlreadyExistsException();
                }
            }
            publications.Add(publication.MyId, publication);
            
        }
        public void addUser(User user)
        {
            if (user != null)
            {
                users.Add(user.myId,user);
            }
        }

        public Publication returnPublicationToRent()
        {
            int id = printer.choosePublicationToRent(publications);
            return publications[id];


        }

    }
}
