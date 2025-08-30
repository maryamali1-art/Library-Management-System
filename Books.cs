using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryManagementSystem
{
    internal class Books
    {
        private static int nextId = 1;
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string PublishingHouse { get; set; }
        public int BookPages { get; set; }

        public Books(string bookName, string bookAuthor, int year, int price, string publishingHouse, int bookPages)
        {
            BookId = nextId;
            nextId++;
            BookName = bookName;
            BookAuthor = bookAuthor;
            Year = year;
            Price = price;
            PublishingHouse = publishingHouse;
            BookPages = bookPages;
        }
        public static Books Create(string bookName, string bookAuthor, int year, int price, string publishingHouse, int bookPages)
        {
            return new Books(bookName, bookAuthor, year, price, publishingHouse, bookPages);
        }
        public static void UpdateNextId(List<Books> books)
        {
            nextId = (books != null && books.Count > 0) ? books.Max(b => b.BookId) + 1 : 1;
        }

        public void ShowDetails()
        {
            Console.WriteLine(" Book Details:");
            Console.WriteLine($"BookId: {BookId}");
            Console.WriteLine($"Name: {BookName}");
            Console.WriteLine($"Author: {BookAuthor}");
            Console.WriteLine($"Year : {Year}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"PublishingHouse: {PublishingHouse}");
            Console.WriteLine($"BookPages: {BookPages}");

            Console.WriteLine("-------------------------------");
        }


    }
}
