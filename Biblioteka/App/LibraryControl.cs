﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
using Biblioteka.Model;
using Biblioteka.Exception;
using Biblioteka.FileM;

namespace Biblioteka
{
    
    public class LibraryControl
    {
        DataReader reader = new DataReader();
        Library library = new Library();
        ConsolePrinter printer = new ConsolePrinter();
        CsvFileManager<Publication> csv = new CsvFileManager<Publication>();
        SerializableFileManager<Publication> serial = new SerializableFileManager<Publication>();
        SerializableFileManager<User> serialUser = new SerializableFileManager<User>();


       public void controlLoop()
        {
            int choice = 10;
            printCsvOrSerialize();
            switch (Console.ReadLine())
            { 
                case "csv":
                    library.Users = csv.importUsers<User>();
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
            if (library == null)
            {
                library = new Library();
            }
            
            do
            {
                printOptions();
                choice = reader.takeInt();
                switch (choice)
                {
                    case (int)Option.ADD_BOOK:
                        addBook();
                        break;
                    case (int)Option.ADD_MAGAZINE:
                        addMagazine();
                        break;
                    case (int)Option.PRINT_BOOK:
                        printBooks();
                        break;
                    case (int)Option.PRINT_MAGAZINE:
                        printMagazine();
                        break;
                    case (int)Option.ADD_READER:
                        addUser();
                        break;
                    case (int)Option.PRINT_READER:
                        printUsers();
                        break;

                    case (int)Option.EXIT:
                        csv.exportData(library);
                        csv.exportUsers(library);
                        try
                        {
                            serial.exportData(library);
                            serialUser.exportData(library);
                        }catch(NotImplementedException e)
                        {
                            Console.WriteLine("Błąd");
                        }
                        Console.WriteLine("Koniec programu, papa");
                        break;

                }
            } while (choice != 0);
            
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
