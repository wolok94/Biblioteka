using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class DataReader
    {
        ConsolePrinter writer = new ConsolePrinter();
        public Book createBook()
        {
            writer.printText("Podaj tytuł książki");
            string title = Console.ReadLine();
            writer.printText("Podaj autora");
            string author = Console.ReadLine();
            writer.printText("Podaj wydawnictwo");
            string publisher = Console.ReadLine();
            writer.printText("Podaj ISBN");
            int isbn = int.Parse(Console.ReadLine());
            writer.printText("Podaj rok wydania");
            int year = int.Parse(Console.ReadLine());
            writer.printText("Podaj liczbę stron");
            int pages = int.Parse(Console.ReadLine());



            return new Book(title, author, isbn, year, publisher, pages,true);
        }
        public Magazine createMagazine()
        {
            writer.printText("Podaj tytuł magazynu");
            string title = Console.ReadLine();
            writer.printText("Podaj autora");
            string author = Console.ReadLine();
            writer.printText("Podaj wydawnictwo");
            string publisher = Console.ReadLine();
            writer.printText("Podaj rok wydania");
            int year = int.Parse(Console.ReadLine());
            writer.printText("Podaj miesiąc wydania");
            int month = int.Parse(Console.ReadLine());



            return new Magazine(title, author, year, month, publisher, false);
        }
        public Reader createReader()
        {
            Console.WriteLine("Podaj imię");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko");
            string lastName = Console.ReadLine();
            Console.WriteLine("Podaj e-mail");
            string eMail = Console.ReadLine();

            return new Reader(name, lastName, eMail);
        }

        public int takeInt()
        {
            int number = int.Parse(Console.ReadLine());
            return number;
        }
    }
}
