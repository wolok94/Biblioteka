using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Biblioteka.Model;

namespace Biblioteka.FileM
{
    public class SerializableFileManager : FileManager
    {
        public void exportData(Library library)
        {
            string serializedLibrary = JsonConvert.SerializeObject(library.Publications);
            File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json", serializedLibrary);
        }

        public SortedDictionary<int, Publication> importData()
        {
            string deserializedLibrary = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json");
            try
            {
                SortedDictionary<int,Publication> publications = 
                    (SortedDictionary<int, Publication>)JsonConvert.DeserializeObject<SortedDictionary<int, Publication>>(deserializedLibrary, new PublicationConverter());
                return publications;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Nie znaleziono bazy");
            }
            return new SortedDictionary<int, Publication>();
            

            
        }


    }
}
