using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var name = Console.ReadLine();

            Console.WriteLine("Hello {0}", name);

            Console.ReadLine();
        }
    }
}