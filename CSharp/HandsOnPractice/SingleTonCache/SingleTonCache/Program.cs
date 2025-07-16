using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SingleTon_Caching
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtaining a singleton instance
            SingleTonCache cache = SingleTonCache.GetInstance();

            // 1. Add some data to the cache
            Console.WriteLine("Adding Keys and Values to the cache----");
            Console.WriteLine($"Adding EID1 as Key to the cache : {cache.Add("EID1", 101)}");
            Console.WriteLine($"Adding EName1 as another key to the cache : {cache.Add("EName1", "Sowmya")}");

            Console.WriteLine($"Adding EID2 as Key to the cache : {cache.Add("EID2", 102)}");
            Console.WriteLine($"Adding EName2 as another key to the cache : {cache.Add("EName2", "Sravya")}");

            Console.WriteLine($"Adding EID3 as Key to the cache : {cache.Add("EID3", 103)}");
            Console.WriteLine($"Adding EName3 as another key to the cache : {cache.Add("EName3", "Sai Satya")}");

            Console.WriteLine("Fetching Data from the collection");
            Console.WriteLine($"Getting Employee ID1 from cache : {cache.Get("EID1")}");
            Console.WriteLine($"Getting Employee Name1 from cache : {cache.Get("EName1")}");

            Console.WriteLine($"Adding or updating EID1 : {cache.AddOrUpdate("EID1", 104)}");
            Console.WriteLine($"Getting updated Employee ID1 from cache : {cache.Get("EID1")}");

            //Console.WriteLine("Removing Key from cache");
            //Console.WriteLine($"Removing EID1 : {cache.Remove("EID1")}");
            //Console.WriteLine($"Getting Employee ID1 from cache : {cache.Get("EID1")}");
            Console.WriteLine();
            Console.WriteLine("Getting all items from the cache:");
            var Items = cache.GetAll();
            foreach (var item in Items)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }

            Console.Read();
        }
    }
}
