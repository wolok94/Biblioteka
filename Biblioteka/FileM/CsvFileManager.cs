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
    public class CsvFileManager<T> : IFileManager<T> where T : Publication
    {
        public readonly string PATH = @"E:\Programowanie\Ćwiczenia\Biblioteka\Biblioteka.txt";
        public void exportData(Library library)
        {
            StringBuilder builder = new StringBuilder();
            var publications = library.Publications.Values;

            foreach (var publication in publications)
            {
                builder.Append(publication.GetType() + ";"
                    + publication.ToString()
                    + Environment.NewLine);

            }
            File.WriteAllText(PATH, builder.ToString());
        }

        public SortedDictionary<int, T> importData()
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
            string[] data = text.Split(";");
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

        public T createBook<T>(string[] data) where T : Book, new()
        {
            int id = int.Parse(data[1]);
            string title = data[2];
            string publisher = data[3];
            int year = int.Parse(data[4]);
            string author = data[5];
            int isbn = int.Parse(data[6]);
            int pages = int.Parse(data[7]);
            bool isBook = true;
            T book = (T)new Book(title, author, isbn, year, publisher, pages, isBook);
            book.setId(id);
            return book;
        }

        public T createMagazine<T>(string[] data) where T : Magazine, new()
        {
            int id = int.Parse(data[1]);
            string title = data[2];
            string author = data[3];
            int year = int.Parse(data[4]);
            int month = int.Parse(data[5]);
            string publisher = data[6];
            bool isBook = false;
            T magazine = (T)new Magazine(title, author, year, month, publisher, isBook);
            magazine.setId(id);
             return magazine;
        }

        public User createUserFromString(string text)
        {
            string[] data = text.Split(";");
            string name = data[0];
            string lastName = data[1];
            string email = data[2];
            bool isAdmin = bool.Parse(data[3]);
            if (isAdmin)
            {
                string password = data[4];


                return new Admin(name, lastName, email, password, isAdmin);
            }
            else
            {
                Reader reader = new Reader(name, lastName, email, isAdmin);
                string[] split = text.Split('/');
                string[] splitPublication = split[split.Length - 1].Split(';');

                if (split.Length > 1)
                {

                    reader.RentedPublications.Add(createObjectFromString(split[1]));
                }



                return reader;
            }
        }
        public void importUser(SortedDictionary<int, User> users)
        {
            if (File.Exists(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt"))
            {
                var library = File.ReadAllLines(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt");
                foreach (var line in library)
                {
                    User user = createUserFromString(line);
                    users.Add(user.myId, user);
                    if (!user.IsAdmin)
                    {
                        Reader reader = (Reader)user;

                    }
                }
            }
        }

        public SortedDictionary<int, User> importUsers()
        {
            SortedDictionary<int, User> users = new SortedDictionary<int, User>();
            importUser(users);
            return users;

        }

        public void exportUsers(Library library)
        {
            StringBuilder builder = new StringBuilder();
            var users = library.Users.Values;

            foreach (var user in users)
            {
                if (user.IsAdmin)
                {
                    Admin admin = (Admin)user;
                    builder.Append(admin.ToString()
    + ";" + admin.Password + Environment.NewLine);
                }
                else
                {
                    builder.Append(user.ToString()
                        + Environment.NewLine);

                }

            }
            File.WriteAllText(@"E:\Programowanie\Ćwiczenia\Biblioteka\Users.txt", builder.ToString());
        }
    }
}
