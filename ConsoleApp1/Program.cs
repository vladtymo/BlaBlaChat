using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dal.DatabaseModel a = new Dal.DatabaseModel(); 
            var s = a.Users.ToList();
            foreach (var item in s)
            {
                Console.WriteLine(item.Email);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
