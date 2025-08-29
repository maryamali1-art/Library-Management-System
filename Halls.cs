using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Halls
    {
        private static int nextId = 1;

        public int HallId { get; set; }
        public string HallName { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public bool IsAvailable { get; set; }
        public Halls(string hallName, int capacity, string location, bool isAvailable)
        {
            HallId = nextId++;
            HallName = hallName;
            Capacity = capacity;
            Location = location;
            IsAvailable = isAvailable;
        }

        private static int GenerateUniqueId()
        {
            // Example: generate a random ID (you can improve this logic)
            return new Random().Next(1000, 9999);
        }


        public static Halls HallsCreate(string HallName, int capacity, string Location, bool IsAvailable)
        {
            return new Halls(HallName, capacity, Location, IsAvailable);


        }
        public void ShowDetailsh()
        {
            Console.WriteLine(" Hall Details:");
            Console.WriteLine($"HallId: {HallId}");
            Console.WriteLine($"Hall Name: {HallName}");
            Console.WriteLine($"Capacity: {Capacity}");
            Console.WriteLine($"Location : {Location}");
            Console.WriteLine($"IsAvailable: {IsAvailable}");
            Console.WriteLine("-------------------------------");
        }


    }
}
