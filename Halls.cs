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

        public static void UpdateNextIdH(List<Halls> hall)
        {
            nextId = (hall != null && hall.Count > 0) ? hall.Max(b => b.HallId) + 1 : 1;
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
