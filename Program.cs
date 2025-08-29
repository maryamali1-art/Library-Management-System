using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Library library = new Library();

            Console.WriteLine("Select your role:");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Admin");
            int role = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine().ToLower();

            if ((role == 1 && password == "user") || (role == 2 && password == "admin"))
            {
                bool keepRunning = true;

                while (keepRunning)
                {
                    Console.WriteLine("\n📂 Main Menu:");
                    Console.WriteLine("1. Books");
                    Console.WriteLine("2. Magazines");
                    Console.WriteLine("3. Halls");
                    Console.WriteLine("4. Readers");
                    Console.WriteLine("5. Borrow & Return");
                    Console.WriteLine("6. Exit");

                    int section = int.Parse(Console.ReadLine());

                    switch (section)
                    {
                        case 1:
                            ShowBooksMenu(library);
                            break;
                        case 2:
                            ShowMagazinesMenu(library);
                            break;
                        case 3:
                            ShowHallsMenu(library);
                            break;
                        case 4:
                            ShowReadersMenu(library);
                            break;
                        case 5:
                            ShowBorrowMenu(library);
                            break;
                        case 6:
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid section.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Access Denied: Incorrect role or password.");
            }
        }

        static void ShowBooksMenu(Library library)
        {
            Console.WriteLine("\n Books Menu:");
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. Search Book");
            Console.WriteLine("5. Update Book");
            Console.WriteLine("6. Back");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: library.Display(); break;
                case 2: library.AddBook(); break;
                case 3: library.DeleteBookById(); break;
                case 4: library.BookSearch(); break;
                case 5: library.UpdateBook(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        static void ShowMagazinesMenu(Library library)
        {
            Console.WriteLine("\n Magazines Menu:");
            Console.WriteLine("1. Display Magazines");
            Console.WriteLine("2. Add Magazine");
            Console.WriteLine("3. Delete Magazine");
            Console.WriteLine("4. Search Magazine");
            Console.WriteLine("5. Update Magazine");
            Console.WriteLine("6. Back");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: library.DisplayMagazines(); break;
                case 2: library.AddMagazine(); break;
                case 3: library.DeleteMagazine(); break;
                case 4: library.SearchMagazine(); break;
                case 5: library.UpdateMagazine(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        static void ShowHallsMenu(Library library)
        {
            Console.WriteLine("\n🏛️ Halls Menu:");
            Console.WriteLine("1. Display Halls");
            Console.WriteLine("2. Add Hall");
            Console.WriteLine("3. Delete Hall");
            Console.WriteLine("4. Search Hall");
            Console.WriteLine("5. Update Hall");
            Console.WriteLine("6. Back");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: library.DisplayHalls(); break;
                case 2: library.AddHall(); break;
                case 3: library.DeleteHall(); break;
                case 4: library.SearchHall(); break;
                case 5: library.UpdateHall(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        static void ShowReadersMenu(Library library)
        {
            Console.WriteLine("\n👤 Readers Menu:");
            Console.WriteLine("1. Display Readers");
            Console.WriteLine("2. Add Reader");
            Console.WriteLine("3. Delete Reader");
            Console.WriteLine("4. Search Reader");
            Console.WriteLine("5. Update Reader");
            Console.WriteLine("6. Back");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: library.DisplayReaders(); break;
                case 2: library.AddReader(); break;
                case 3: library.DeleteReader(); break;
                case 4: library.SearchReader(); break;
                case 5:
                    library.ReaderUpdate();
                    break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        static void ShowBorrowMenu(Library library)
        {

            Console.WriteLine("\n🔄 Borrow & Return Menu:");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Borrow Magazine");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Return Magazine");
            Console.WriteLine("5. Rent Hall");
            Console.WriteLine("6. Back");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: library.BorrowBook(); break;
                case 2: library.BorrowMagazine(); break;
                case 3: library.ReturnBook(); break;
                case 4: library.ReturnMagazine(); break;
                case 5: library.RentHall(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
