using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.NetworkInformation;

namespace LibraryManagementSystem
{
    internal class Library
    {
        private List<Books> books = new List<Books>();
        private List<Magazine> magazine = new List<Magazine>();
        private List<Reader> reader = new List<Reader>();
        private List<Halls> halls = new List<Halls>();
        private List<Borrowing> borrow = new List<Borrowing>();

        public List<T> ReadFromJson<T>(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                return new List<T>();
            }
        }

        //public void ReadBooks()
        //{
        //    string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";

        //    int nextId;
        //    if (File.Exists(path))
        //    {
        //        string json = File.ReadAllText(path);
        //        books = JsonSerializer.Deserialize<List<Books>>(json) ?? new List<Books>();
        //    }
        //    else
        //    {
        //        books = new List<Books>();
        //    }
        //    if (books.Count > 0)
        //    {
        //        nextId = books.Max(b => b.BookId) + 1;
        //    }
        //    else
        //    {
        //        nextId = 1;
        //    }
        //}
        public void Display()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path); // ← تحديد النوع وتخزين النتيجة

            foreach (var book in books)
            {
                book.ShowDetails();
            }
        }
        public void AddBook()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path);

            Console.WriteLine("Enter Book name:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Book Author:");
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("Enter Year:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Publishing House:");
            string publishingHouse = Console.ReadLine();

            Console.WriteLine("Enter Number of Pages:");
            int bookPages = int.Parse(Console.ReadLine());

            Books newBook = Books.Create(title, bookAuthor, year, price, publishingHouse, bookPages);

            books.Add(newBook);
            SaveToJson<Books>(books, path);

            Console.WriteLine("✅ Book added successfully.");
        }

        public static void SaveToJson<T>(List<T> data, string path)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void DeleteBookById()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path);

            Console.WriteLine("Enter the Book Id to delete:");
            int id = int.Parse(Console.ReadLine());

            var bookToRemove = books.FirstOrDefault(b => b.BookId == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"The book has been deleted: {bookToRemove.BookName}");
                SaveToJson<Books>(books, path);
            }
            else
            {
                Console.WriteLine("No book was found with this ID.");
            }
        }
        public void BookSearch()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path);

            Console.WriteLine("Enter part or full title of the book:");
            string inputTitle = Console.ReadLine().ToLower();

            var matchedBooks = books
                .Where(b => b.BookName.ToLower().Contains(inputTitle))
                .ToList();

            if (matchedBooks.Any())
            {
                Console.WriteLine($"Found {matchedBooks.Count} book(s):");
                foreach (var book in matchedBooks)
                {
                    Console.WriteLine($"{book.BookName} by {book.BookAuthor} ({book.Year})");
                    Console.WriteLine($"   Price: {book.Price}, Pages: {book.BookPages}, Publisher: {book.PublishingHouse}");
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No books matched your search.");
            }
        }

        public void UpdateBook()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path);

            Console.WriteLine("Enter the Book ID to update:");
            int id = int.Parse(Console.ReadLine());

            var index = books.FindIndex(b => b.BookId == id);
            if (index != -1)
            {
                Console.WriteLine("Enter new Book name:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter new Book Author:");
                string author = Console.ReadLine();

                Console.WriteLine("Enter new Year:");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Price:");
                int price = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Publishing House:");
                string publisher = Console.ReadLine();

                Console.WriteLine("Enter new Number of Pages:");
                int pages = int.Parse(Console.ReadLine());
                books[index].BookName = title;
                books[index].BookAuthor = author;
                books[index].Year = year;
                books[index].Price = price;
                books[index].PublishingHouse = publisher;
                books[index].BookPages = pages;

                Console.WriteLine($"Book updated: {books[index].BookName}");
                SaveToJson<Books>(books, path);
            }
            else
            {
                Console.WriteLine("No book was found with this ID.");
            }
        }
        public void BorrowBook()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            books = ReadFromJson<Books>(path);
            Console.WriteLine("Enter Reader ID:");
            int readerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book ID:");
            int itemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter type:");
            string type = Console.ReadLine();

            DateTime borrowDate = DateTime.Now;
            DateTime dueDate = borrowDate.AddDays(14);

            Borrowing borrow1 = Borrowing.Create(readerId, itemId, type);
            borrow.Add(borrow1);
            Console.WriteLine("✅ Book borrowed successfully.");
            SaveToJson<Books>(books, path);
        }
        public void ReturnBook()
        {
            string BookPath = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Books.json";
            string borrowPath = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Borrowing.json";

            List<Books> books = ReadFromJson<Books>(BookPath);
            List<Borrowing> borrowings = ReadFromJson<Borrowing>(borrowPath);

            Console.WriteLine("Enter Reader ID:");
            int readerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book ID:");
            int itemId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter type:");
            string type = Console.ReadLine();

            Borrowing returnedBorrow = Borrowing.Create(readerId, itemId, type);
            returnedBorrow.IsReturned = true;

            borrowings.Add(returnedBorrow);

            SaveToJson<Borrowing>(borrowings, borrowPath);
            Console.WriteLine("Book returned successfully.");
        }
        public void RentHall()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            List<Halls> hallsList = ReadFromJson<Halls>(path);

            Console.WriteLine("Enter reader name:");
            string readerName = Console.ReadLine();
            Console.WriteLine("Enter reader address:");
            string readerAddress = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            int phoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter hall name:");
            string hallName = Console.ReadLine();
            Console.WriteLine("Enter capacity:");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter location:");
            string location = Console.ReadLine();
            bool isAvailable = true;

            Rent rentHall = Rent.RentCreate(readerName, readerAddress, phoneNumber, hallName,
                capacity, location, isAvailable);
            rentHall.IsAvailable = true;

            // Assuming you have a list to store rents
            List<Rent> rentList = new List<Rent>();
            rentList.Add(rentHall);

            // Save to JSON
            string rentPath = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Rents.json";
            SaveToJson<Rent>(rentList, rentPath);

            Console.WriteLine("Hall rented successfully.");
        }
        /// <summary>
        /// Magazines
        /// </summary>
        public void DisplayMagazines()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            magazine = ReadFromJson<Magazine>(path);

            foreach (var m in magazine)
            {
                m.ShowDetailsm();
            }
        }
        public void AddMagazine()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            List<Magazine> magazines = ReadFromJson<Magazine>(path);

            Console.WriteLine("Enter Magazine name:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Publisher:");
            string publisher = Console.ReadLine();

            Console.WriteLine("Enter Category:");
            string category = Console.ReadLine();

            Console.WriteLine("Enter Issue Number:");
            int issueNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Release Date (e.g., 2025-08-29):");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Page Count:");
            int pageCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            int price = int.Parse(Console.ReadLine());

            Magazine newMagazine = Magazine.MagazineCreate(title, publisher, category, issueNumber, releaseDate, pageCount, price);
            magazines.Add(newMagazine);

            SaveToJson<Magazine>(magazines, path);
            Console.WriteLine("Magazine added successfully.");
        }
        public void DeleteMagazine()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            List<Magazine> magazines = ReadFromJson<Magazine>(path);

            Console.WriteLine("Enter the Magazine ID to delete:");
            int id = int.Parse(Console.ReadLine());

            var magazineToRemove = magazines.FirstOrDefault(m => m.MagazineId == id);
            if (magazineToRemove != null)
            {
                magazines.Remove(magazineToRemove);
                Console.WriteLine($"Magazine deleted: {magazineToRemove.Title}");
                SaveToJson<Magazine>(magazines, path);
            }
            else
            {
                Console.WriteLine("No magazine was found with this ID.");
            }
        }
        public void SearchMagazine()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            List<Magazine> magazines = ReadFromJson<Magazine>(path);

            Console.WriteLine("Enter the magazine title:");
            string inputTitle = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(inputTitle))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            var foundMagazine = magazines.FirstOrDefault(m =>
                m.Title.Equals(inputTitle, StringComparison.OrdinalIgnoreCase));

            if (foundMagazine != null)
            {
                Console.WriteLine($"Found: {foundMagazine.Title} | Category: {foundMagazine.Category} | Publisher: {foundMagazine.Publisher}");
            }
            else
            {
                Console.WriteLine("Magazine not found.");
            }
        }

        public void UpdateMagazine()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            List<Magazine> magazines = ReadFromJson<Magazine>(path);

            Console.WriteLine("Enter the Magazine ID to update:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Magazine name:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter new Publisher:");
            string publisher = Console.ReadLine();

            Console.WriteLine("Enter new Category:");
            string category = Console.ReadLine();

            Console.WriteLine("Enter new Issue Number:");
            int issueNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Release Date (e.g., 2025-08-29):");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Page Count:");
            int pageCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Price:");
            int price = int.Parse(Console.ReadLine());

            var index = magazines.FindIndex(m => m.MagazineId == id);
            if (index != -1)
            {
                Magazine updatedMagazine = Magazine.MagazineCreate(title, publisher, category, issueNumber, releaseDate, pageCount, price);
                updatedMagazine.MagazineId = id;
                magazines[index] = updatedMagazine;

                Console.WriteLine($"Magazine updated: {updatedMagazine.Title}");
                SaveToJson<Magazine>(magazines, path);
            }
            else
            {
                Console.WriteLine("No magazine was found with this ID.");
            }
        }
        public void BorrowMagazine()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            List<Magazine> magazines = ReadFromJson<Magazine>(path);
            Console.WriteLine("Enter Reader ID:");
            int readerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Magazine ID:");
            int itemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter type:");
            string type = Console.ReadLine();

            DateTime borrowDate = DateTime.Now;
            DateTime dueDate = borrowDate.AddDays(14);

            Borrowing borrow1 = Borrowing.Create(readerId, itemId, type);
            borrow.Add(borrow1);
            Console.WriteLine("Magazine borrowed successfully.");
            SaveToJson<Magazine>(magazine, path);
        }
        public void ReturnMagazine()
        {
            string magazinePath = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\magazine.json";
            string borrowPath = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Borrowing.json";

            List<Magazine> magazines = ReadFromJson<Magazine>(magazinePath);
            List<Borrowing> borrowings = ReadFromJson<Borrowing>(borrowPath);

            Console.WriteLine("Enter Reader ID:");
            int readerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Magazine ID:");
            int itemId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter type:");
            string type = Console.ReadLine();

            Borrowing returnedBorrow = Borrowing.Create(readerId, itemId, type);
            returnedBorrow.IsReturned = true;

            borrowings.Add(returnedBorrow);

            SaveToJson<Borrowing>(borrowings, borrowPath);
            Console.WriteLine("Magazine returned successfully.");
        }
        /// <summary>
        /// Readers
        /// </summary>
        public void DisplayReaders()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Reader.json";
            reader = ReadFromJson<Reader>(path);

            foreach (var r in reader)
            {
                r.ShowDetailsr();
            }
        }
        public void AddReader()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Reader.json";
            List<Reader> readers = ReadFromJson<Reader>(path);

            Console.WriteLine("Enter Reader name:");
            string readerName = Console.ReadLine();

            Console.WriteLine("Enter Reader address:");
            string readerAddress = Console.ReadLine();

            Console.WriteLine("Enter Phone number:");
            int phoneNumber = int.Parse(Console.ReadLine());

            Reader newReader = Reader.ReaderCreate(readerName, readerAddress, phoneNumber);
            readers.Add(newReader);

            SaveToJson<Reader>(readers, path);
            Console.WriteLine($"Reader added: {newReader.ReaderName}");
        }
        public void DeleteReader()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Reader.json";
            List<Reader> readers = ReadFromJson<Reader>(path);

            Console.WriteLine("Enter the Reader ID to delete:");
            int id = int.Parse(Console.ReadLine());

            var readerToRemove = readers.FirstOrDefault(r => r.ReaderId == id);
            if (readerToRemove != null)
            {
                readers.Remove(readerToRemove);
                Console.WriteLine($"Reader has been deleted: {readerToRemove.ReaderName}");
                SaveToJson<Reader>(readers, path);
            }
            else
            {
                Console.WriteLine("No Reader was found with this ID.");
            }
        }
        public void SearchReader()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Reader.json";
            List<Reader> readers = ReadFromJson<Reader>(path);

            Console.WriteLine("Enter the reader's name to search:");
            string searchName = Console.ReadLine();

            var foundReader = readers.FirstOrDefault(r => r.ReaderName.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (foundReader != null)
            {
                Console.WriteLine("\nReader found:");
                Console.WriteLine($"ID: {foundReader.ReaderId}");
                Console.WriteLine($"Name: {foundReader.ReaderName}");
                Console.WriteLine($"Address: {foundReader.ReaderAddreas}");
                Console.WriteLine($"Phone Number: {foundReader.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("No reader found with that name.");
            }
        }

        public void ReaderUpdate()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Reader.json";
            List<Reader> readers = ReadFromJson<Reader>(path);

            Console.WriteLine("Enter the Reader ID to update:");
            int id = int.Parse(Console.ReadLine());

            var index = readers.FindIndex(r => r.ReaderId == id);
            if (index != -1)
            {
                Console.WriteLine("Enter new Reader name:");
                string readerName = Console.ReadLine();

                Console.WriteLine("Enter new Reader address:");
                string readerAddress = Console.ReadLine();

                Console.WriteLine("Enter new Phone number:");
                int phoneNumber = int.Parse(Console.ReadLine());

                Reader updatedReader = Reader.ReaderCreate(readerName, readerAddress, phoneNumber);
                updatedReader.ReaderId = id;

                readers[index] = updatedReader;

                SaveToJson<Reader>(readers, path);
                Console.WriteLine($"Reader updated: {updatedReader.ReaderName}");
            }
            else
            {
                Console.WriteLine("No Reader was found with this ID.");
            }
        }
        /// <summary>
        /// Halls
        /// </summary>
        public void DisplayHalls()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            halls = ReadFromJson<Halls>(path);

            foreach (var h in halls)
            {
                h.ShowDetailsh();
            }
        }
        public void AddHall()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            List<Halls> hallsList = ReadFromJson<Halls>(path);

            Console.WriteLine("Enter Hall name:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Capacity:");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Location:");
            string location = Console.ReadLine();

            Console.WriteLine("Is the hall available? (yes/no):");
            string input = Console.ReadLine().ToLower();
            bool isAvailable = input == "yes" || input == "y";

            Halls newHall = Halls.HallsCreate(title, capacity, location, isAvailable);
            hallsList.Add(newHall);

            SaveToJson<Halls>(hallsList, path);
            Console.WriteLine($"Hall added: {newHall.HallName} at {newHall.Location}");
        }
        public void DeleteHall()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            List<Halls> halls = ReadFromJson<Halls>(path);

            Console.WriteLine("Enter the Hall ID to delete:");
            int id = int.Parse(Console.ReadLine());

            var hallToRemove = halls.FirstOrDefault(h => h.HallId == id);
            if (hallToRemove != null)
            {
                halls.Remove(hallToRemove);
                Console.WriteLine($"Hall deleted: {hallToRemove.HallName}");
                SaveToJson<Halls>(halls, path);
            }
            else
            {
                Console.WriteLine("No hall was found with this ID.");
            }
        }
        public void SearchHall()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            List<Halls> halls = ReadFromJson<Halls>(path);

            Console.WriteLine("Enter the hall name to search:");
            string hallName = Console.ReadLine()?.Trim();

            var hall = halls.FirstOrDefault(h => h.HallName.Equals(hallName, StringComparison.OrdinalIgnoreCase));

            if (hall != null)
            {
                Console.WriteLine($"✅ Found: {hall.HallName} | Capacity: {hall.Capacity} | Available: {(hall.IsAvailable ? "Yes" : "No")}");
            }
            else
            {
                Console.WriteLine("❌ Hall not found.");
            }
        }

        public void UpdateHall()
        {
            string path = @"C:\Users\master\Desktop\C#OOP\LibraryManagementSystem\Halls.json";
            List<Halls> halls = ReadFromJson<Halls>(path);

            Console.WriteLine("Enter the Hall ID to update:");
            int id = int.Parse(Console.ReadLine());

            var index = halls.FindIndex(h => h.HallId == id);
            if (index != -1)
            {
                Console.WriteLine("Enter new Hall name:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter new Capacity:");
                int capacity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Location:");
                string location = Console.ReadLine();

                Console.WriteLine("Is the hall available? (yes/no):");
                string input = Console.ReadLine().ToLower();
                bool isAvailable = input == "yes" || input == "y";

                Halls updatedHall = new Halls(title, capacity, location, isAvailable);
                updatedHall.HallId = id;
                halls[index] = updatedHall;

                Console.WriteLine($"Hall updated: {updatedHall.HallName}");
                SaveToJson<Halls>(halls, path);
            }
            else
            {
                Console.WriteLine("No hall was found with this ID.");
            }
        }
    }
}