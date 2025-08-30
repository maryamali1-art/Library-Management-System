using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{

    internal class Borrowing
    {
        public int ReaderId { get; set; }
        public int ItemId { get; set; }
        public string Type { get; set; }
        public bool IsReturned { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

       
        public static Borrowing BorrowingCreate(int readerId, int itemId, string type)
        {
            return new Borrowing(readerId, itemId, type, DateTime.Now, DateTime.Now.AddDays(14));
        }

       
        public Borrowing(int readerId, int itemId, string type, DateTime borrowDate, DateTime dueDate)
        {
            ReaderId = readerId;
            ItemId = itemId;
            Type = type;
            BorrowDate = borrowDate;
            DueDate = dueDate;
            IsReturned = false;
        }

        //public void MarkAsReturned(DateTime returnDate)
        //{
        //    IsReturned = true;
        //    ReturnDate = returnDate;
        //}


    }
}


