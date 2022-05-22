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
    public class CsvFileManager : FileManager
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

        public Library importData()
        {
            Library library = new Library();
            importPublication(library);
            return library;
        }
        public void importPublication(Library lib)
        {

            var library = File.ReadAllLines(@"E:\Programowanie\Ćwiczenia\Biblioteka\Biblioteka.txt");
            foreach (var line in library)
            {
                Publication publication = createObjectFromString(line);
                lib.Publications.Add(publication.Title, publication);
             }
            
        }
        public Publication createObjectFromString(String text)
        {
            string [] data = text.Split(";");
            string type = data[0];
            if (Book.TYPE.ToString().Equals(type))
            {
                return createBook(data);
            }
            else if (Magazine.TYPE.Equals(type))
            {
                return createMagazine(data);
            }
            throw new InvalidDataException($"Nieznany typ publikacji {type}");


        }
        public Book createBook(string [] data)
        {
            string title = data[1];
            string publisher = data[2];
            int year = int.Parse(data[3]);
            string author = data[4];
            int isbn = int.Parse(data[5]);
            int pages = int.Parse(data[6]);

            return new Book(title, author, isbn, year, publisher, pages);
        }
        public Magazine createMagazine(string [] data)
        {
            string title = data[1];
            string author = data[2];
            int year = int.Parse(data[3]);
            int month = int.Parse(data[4]);
            string publisher = data[5];


            return new Magazine(title,author,year,month,publisher);
        }
    }
}
