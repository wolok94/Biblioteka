using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Biblioteka.Model;
using Biblioteka.Exception;

namespace Biblioteka.FileM
{
    public class SerializableFileManager : FileManager
    {
        public void exportData(Library library)
        {
            string serializedLibrary = JsonConvert.SerializeObject(library.Publications, new PublicationConverter());
            File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json", serializedLibrary);
        }

        public SortedDictionary<int, Publication> importData()
        {
            string deserializedLibrary = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json");
            try
            {
                SortedDictionary<int,Publication> publications = 
                    (SortedDictionary<int, Publication>)JsonConvert.DeserializeObject<SortedDictionary<int, Publication>>(deserializedLibrary, new PublicationConverter());
                if (publications == null)
                {
                    publications = new SortedDictionary<int, Publication>();
                }
                return publications;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Nie znaleziono bazy");
            }
            throw new DeserializedDictionaryIsEmptyException();
            

            
        }


    }
}
