using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
using Biblioteka.Model;
using Biblioteka.Exception;
using Biblioteka.FileM;
using System.Security.Cryptography;

namespace Biblioteka
{
    
    public class LibraryControl
    {
        private DataReader reader = new DataReader();
        private Library library = new Library();
        private ConsolePrinter printer = new ConsolePrinter();
        private CsvFileManager<Publication> csv = new CsvFileManager<Publication>();
        private SerializableFileManager<Publication> serial = new SerializableFileManager<Publication>();
        private SerializableFileManager<User> serialUser = new SerializableFileManager<User>();
        private User actuallyUser;


       public void controlLoop()
        {
            int choice = 10;
            printCsvOrSerialize();
            switch (Console.ReadLine())
            { 
                case "csv":
                    library.Users = csv.importUsers();
                    library.Publications = csv.importData();
                    break;
                case "serial":
                    try
                    {
                        library.Publications = serial.importData();
                        library.Users = serialUser.importData();
                    } catch (Newtonsoft.Json.JsonSerializationException e)
                    {
                        Console.WriteLine("Błąd");
                    } catch (DeserializedDictionaryIsEmptyException e)
                    {
                        Console.WriteLine("Baza jest pusta");
                    }
                    break;

            }
            Console.Clear();
            if (library == null)
            {
                library = new Library();
            }
            hello();
            
        }
        void hello()
        {
            Console.WriteLine("Witaj w bibliotece\n" +
                "1. Zaloguj się\n" +
                "2. Koniec");
            switchHello();
        }
        private void switchHello()
        {
            int choice = 0;
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        bool isAdmin = false;
                        actuallyUser = logIn(out isAdmin);
                        if (isAdmin)
                        {
                            Console.Clear();
                            switchOption();
                        }
                        else
                        {
                            Console.Clear();
                            switchOptionUser();
                        }
                        break;

                }
            } while (choice != 2);

        }
        string getPassword()
        {

            string password = string.Empty;
            ConsoleKey key;
            
            do
            {
                var keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
               if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
            }

        User logIn(out bool isAdmin)
        {
            User actuallyUser = null;
            isAdmin = false;
            do
            {
                Console.WriteLine("Podaj email");
                string email = Console.ReadLine();
                actuallyUser = library.Users.Values.FirstOrDefault(u => u.email.Equals(email));
            } while (actuallyUser == null);
            if (actuallyUser is Admin)
            {
                Admin actuallyAdmin = (Admin)actuallyUser;
                string password;
                do
                {
                    Console.WriteLine("Podaj hasło");
                    password = getPassword();
                    Console.WriteLine();
                    Console.Clear();
                    isAdmin = true;
                } while (password != actuallyAdmin.Password);

                
            }

            
            return actuallyUser;
        }
        void switchOptionUser()
        {
            int choice = 0;
            do
            {
                if (actuallyUser is Reader)
                    printOptionForUsers();
                Reader reader = (Reader)actuallyUser;
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        reader.rentPublication(library.returnPublicationToRent());
                        break;
                    case 2:
                        printer.printRentedPublications(actuallyUser);
                        break;
                    case 3:
                        csv.exportData(library);
                        csv.exportUsers(library);
                        try
                        {
                            serial.exportData(library);
                            serialUser.exportData(library);
                        }
                        catch (NotImplementedException e)
                        {
                            Console.WriteLine("Błąd");
                        }
                        Console.WriteLine("Koniec programu, papa");
                        break;
                }
            } while (choice != 3);
        }
        void switchOption()
        {
            int choice;
            do
            {
                printOptions();
               choice = reader.takeInt();
                switch (choice)
                {
                    case (int)Option.ADD_BOOK:
                        Console.Clear();
                        addBook();
                        break;
                    case (int)Option.ADD_MAGAZINE:
                        Console.Clear();
                        addMagazine();
                        break;
                    case (int)Option.PRINT_BOOK:
                        Console.Clear();
                        printBooks();
                        break;
                    case (int)Option.PRINT_MAGAZINE:
                        Console.Clear();
                        printMagazine();
                        break;
                    case (int)Option.ADD_READER:
                        Console.Clear();
                        addUser();
                        break;
                    case (int)Option.PRINT_READER:
                        Console.Clear();
                        printUsers();
                        break;

                    case (int)Option.EXIT:
                        csv.exportData(library);
                        csv.exportUsers(library);
                        try
                        {
                            serial.exportData(library);
                            serialUser.exportData(library);
                        }
                        catch (NotImplementedException e)
                        {
                            Console.WriteLine("Błąd");
                        }
                        Console.WriteLine("Koniec programu, papa");
                        break;

                }
            } while (choice != 0);
        }
        void printOptionForUsers()
        {
            Console.WriteLine("1. Wypożycz książkę\n" +
                "2. Wyświetl wypożyczone książki\n" +
                "3. Koniec");
        }
        void addUser()
        {
            Reader read = reader.createReader();
          
                library.addUser(read);
            
        }
        void addBook()
        {
            Book book = reader.createBook();
            try
            {
                library.addPublication(book);
            }catch (PublicationAlreadyExistsException e)
            {
                Console.WriteLine("Taka książka już istnieje");
            }
        }

        void addMagazine()
        {
            Magazine magazine = reader.createMagazine();
            try
            {
                library.addPublication(magazine);
            }catch (PublicationAlreadyExistsException e)
            {
                Console.WriteLine("Taki magazyn już istnieje");
            }
        }
        void printBooks()
        {

            printer.printBooks(library.Publications);
        }
        void printMagazine()
        {
            printer.printMagazine(library.Publications);
        }
        void printUsers()
        {
            printer.printUsers(library.Users);
        }
        void printOptions()
        {
            Console.WriteLine("1. Dodaj książkę\n" +
                "2. Dodaj magazyn\n" +
                "3. Wypisz książki\n" +
                "4. Wypisz magazyny\n" +
                "5. Dodaj użytkownika\n" +
                "6. Wypisz użytkowników");
        }
        void printCsvOrSerialize()
        {
            Console.WriteLine("Csv\n" +
                "Serial");
        }
        enum Option
        {
            ADD_BOOK = 1,
            ADD_MAGAZINE = 2,
            PRINT_BOOK = 3,
            PRINT_MAGAZINE = 4,
            ADD_READER = 5,
            PRINT_READER = 6,
            EXIT = 0,


        }
        enum CsvOrSerialize
        {
            CSV,
            Serial,
        }
    }

}
