using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Rent : Halls
    {
        public string ReaderName { get; set; }
        public string ReaderAddress { get; set; }
        public int PhoneNumber { get; set; }

        public Rent(string readerName, string readerAddress, int phoneNumber,
                    string hallName, int capacity, string location, bool isAvailable)
            : base(hallName, capacity, location, isAvailable)
        {
            ReaderName = readerName;
            ReaderAddress = readerAddress;
            PhoneNumber = phoneNumber;
        }

        public static Rent RentCreate(string readerName, string readerAddress, int phoneNumber,
                                      string hallName, int capacity, string location, bool isAvailable)
        {
            return new Rent(readerName, readerAddress, phoneNumber, hallName, capacity, location, isAvailable);
        }
    }
}
