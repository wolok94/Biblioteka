using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Biblioteka.FileM;
using Biblioteka.Model;

namespace Biblioteka.FileM
{
    public class CsvFileManager<T> : FileManager<T> where T : Publication
    {
        public readonly string PATH = @"E:\Programowanie\Ćwiczenia\Biblioteka\Biblioteka.txt";
        public void exportData(Library library)
        {
            StringBuilder builder = new StringBuilder();
            var publications = library.Publications.Values;

            foreach(var publication in publications)
            {
                builder.Append(publication.GetType() + ";" 
                    + publication.ToString() 
                    + Environment.NewLine);
                
            }
            File.WriteAllText(PATH, builder.ToString());
        }

        public SortedDictionary<int,T> importData()
        {
            SortedDictionary<int, T> publications = new SortedDictionary<int, T>();
            importPublication<T>(publications);
            return publications;
        }
       
        public void importPublication<T>(SortedDictionary<int, T> publications) where T : Publication
        {

            var library = File.ReadAllLines(@"E:\Programowanie\Ćwiczenia\Biblioteka\Biblioteka.txt");
            foreach (var line in library)
            {
                T publication = (T)createObjectFromString(line);
                publications.Add(publication.MyId, publication);
             }
            
        }
        
        public Publication createObjectFromString(string text) 
          
        {
            string [] data = text.Split(";");
            string type = data[0];
            if (Book.TYPE.ToString().Equals(type))
            {
                return createBook<Book>(data);
            }
            else if (Magazine.TYPE.Equals(type))
            {
                return createMagazine<Magazine>(data);
            }
            throw new InvalidDataException($"Nieznany typ publikacji {type}");


        }
       
        public T createBook<T>(string [] data) where T : Book, new()
        {
            
            string title = data[1];
            string publisher = data[2];
            int year = int.Parse(data[3]);
            string author = data[4];
            int isbn = int.Parse(data[5]);
            int pages = int.Parse(data[6]);
            int id = int.Parse(data[7]);
            T book = new T();
            book.Title = title;
            book.Publisher = publisher;
            book.Year = year;
            book.Author = author;
            book.Isbn = isbn;
            book.Pages = pages;
            book.IsBook = true;
            book.Type = Book.TYPE;
            book.MyId = id;
            book.Id = id;
            return book;
        }
        
        public T createMagazine<T>(string [] data)  where T : Magazine, new ()
        {
            string title = data[1];
            string author = data[2];
            int year = int.Parse(data[3]);
            int month = int.Parse(data[4]);
            string publisher = data[5];
            int id = int.Parse(data[6]);
            T magazine = new T();
            magazine.Title = title;
            magazine.Author = author;
            magazine.Year = year;
            magazine.Month = month;
            magazine.Publisher = publisher;
            magazine.IsBook = false;
            magazine.MyId = id;

            return magazine;
        }
       
        public User createUserFromString(string text)
        {
            string[] data = text.Split(";");
            string name = data[0];
            string lastName = data[1];
            string email = data[2];
            
            return new Reader(name,lastName, email);
        }
        public void importUser <T>(SortedDictionary<int, T> users) where T : User
        {
            if (File.Exists(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt"))
            {
                var library = File.ReadAllLines(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt");
                foreach (var line in library)
                {
                    T user = (T)createUserFromString(line);
                    users.Add(user.myId, user);
                }
            }
        }
        
        public SortedDictionary<int, T> importUsers<T>() where T : User
        {
            SortedDictionary<int, T> users = new SortedDictionary<int, T>();
            importUser<T>(users);
            return users;

        }

        public void exportUsers(Library library)
        {
            StringBuilder builder = new StringBuilder();
            var users = library.Users.Values;

            foreach (var user in users)
            {
                builder.Append(user.ToString()
                    + Environment.NewLine);

            }
            File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt", builder.ToString());
        }
    }
}
