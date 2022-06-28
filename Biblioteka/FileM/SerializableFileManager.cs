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
    public class SerializableFileManager<T> : IFileManager<T>
    {
        public void exportData(Library library)
        {
            string serializedLibrary;
            if (typeof(T).Equals(typeof(Publication)))
            {
                serializedLibrary = JsonConvert.SerializeObject(library.Publications, new DataConverter<T>());
                File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json", serializedLibrary);
            }
            else
            {
                serializedLibrary = JsonConvert.SerializeObject(library.Users, new DataConverter<T>());
                File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedUsers.Json", serializedLibrary);
            }
                
        }


        public  SortedDictionary<int, T>  importData()
        {
            string deserializedLibrary;
            if (typeof(T).Equals(typeof(Publication)))
            {
                deserializedLibrary = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedLibrary.Json");
            }
            else
            {
                deserializedLibrary = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\SerializedUsers.Json");
            }
            
            try
            {
                SortedDictionary<int,T> publications = 
                    (SortedDictionary<int, T>)JsonConvert.DeserializeObject<SortedDictionary<int, T>>(deserializedLibrary, new DataConverter<T>());
                if (publications == null)
                {
                    publications = new SortedDictionary<int, T>();
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
    

