using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Exception;

namespace Biblioteka
{
    public class Library
    {

        private SortedDictionary<string, Publication> publications = new SortedDictionary<string, Publication>();

        public SortedDictionary<string, Publication> Publications { get => publications; set => publications = value; }

        public void addPublication(Publication publication)
        {
            if (publications.ContainsKey(publication.Title))
            {
                throw new PublicationAlreadyExistsException();
            }
            Publications.Add(publication.Title, publication);
        }

    }
}
