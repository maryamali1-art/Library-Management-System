using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Magazine
    {
        private static int nextId = 1;

        public int MagazineId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public int IssueNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }

        public Magazine(string title, string publisher, string category, int issueNumber, DateTime releaseDate, int pageCount, double price)
        {
            MagazineId = nextId++;
            Title = title;
            Publisher = publisher;
            Category = category;
            IssueNumber = issueNumber;
            ReleaseDate = releaseDate;
            PageCount = pageCount;
            Price = price;
        }
        public static Magazine MagazineCreate(string Title, string Publisher, string Category,
            int IssueNumber, DateTime ReleaseDate, int PageCount, int Price)
        {
            return new Magazine(Title, Publisher, Category, IssueNumber, ReleaseDate, PageCount, Price);
        }
        public void ShowDetailsm()
        {
            Console.WriteLine(" Magazine Details:");
            Console.WriteLine($"MagazineId: {MagazineId}");
            Console.WriteLine($"Name: {Title}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Category : {Category}");
            Console.WriteLine($"IssueNumber: {IssueNumber}");
            Console.WriteLine($"ReleaseDate: {ReleaseDate}");
            Console.WriteLine($"PageCount: {PageCount}");
            Console.WriteLine($"Price: {Price}");

            Console.WriteLine("-------------------------------");
        }

    }
}

