using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Reader
    {
        public static int NextId = 1;
        public int ReaderId { get; set; }
        public string ReaderName { get; set; }
        public string ReaderAddreas { get; set; }
        public string PhoneNumber { get; set; }
        public Reader(string readerName, string readerAddreas, string phoneNumber)
        {
            ReaderId = NextId++;
            ReaderName = readerName;
            ReaderAddreas = readerAddreas;
            PhoneNumber = phoneNumber;


        }
        public static void UpdateNextIdR(List<Reader> reader)
        {
            NextId = (reader != null && reader.Count > 0) ? reader.Max(b => b.ReaderId) + 1 : 1;
        }
        public static Reader ReaderCreate(string ReaderName, string ReaderAddreas, string PhoneNumber)
        {
            return new Reader(ReaderName, ReaderAddreas, PhoneNumber);
        }
        public void ShowDetailsr()
        {
            Console.WriteLine(" Reader Details:");
            Console.WriteLine($"ReaderId: {ReaderId}");
            Console.WriteLine($"ReaderName: {ReaderName}");
            Console.WriteLine($"ReaderAddreas: {ReaderAddreas}");
            Console.WriteLine($"PhoneNumber : {PhoneNumber}");

            Console.WriteLine("-------------------------------");
        }


    }
}