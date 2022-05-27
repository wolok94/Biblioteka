using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Biblioteka.FileM
{
    public class SerializableFileManager : FileManager
    {
        public void exportData(Library library)
        {
            string serializedLibrary = JsonConvert.SerializeObject(library);
            File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json", serializedLibrary);
        }

        public Library importData()
        {
            string deserializedLibrary = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json");
            try
            {
                Library library = (Library)JsonConvert.DeserializeObject<Library>(deserializedLibrary);
                return library;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Nie znaleziono bazy");
            }
            return new Library();
            

            
        }


    }
}
