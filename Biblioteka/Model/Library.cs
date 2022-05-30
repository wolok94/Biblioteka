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

        public SortedDictionary<int, Publication> Publications { get => publications; set => publications = value; }
        public SortedDictionary<int, User> Users { get => users; set => users = value; }

        public void addPublication(Publication publication)
        {
            if (publications != null)
            {
                if (publications.ContainsKey(publication.Id))
                {
                    throw new PublicationAlreadyExistsException();
                }
            }
            publications.Add(publication.Id, publication);
            
        }
        public void addUser(User user)
        {
            if (user != null)
            {
                users.Add(user.myId,user);
            }
        }

    }
}
