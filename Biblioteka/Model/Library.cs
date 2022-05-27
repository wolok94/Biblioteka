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

        public SortedDictionary<int, Publication> Publications { get => publications; set => publications = value; }

        public void addPublication(Publication publication)
        {
            if (publications.ContainsKey(publication.Id))
            {
                throw new PublicationAlreadyExistsException();
            }
            Publications.Add(publication.Id, publication);
        }

    }
}
