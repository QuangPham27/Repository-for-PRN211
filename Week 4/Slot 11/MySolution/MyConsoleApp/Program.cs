using System;
using static MyLibrary.MyClass;

namespace MyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 50, b = 25;
            int result;
            Console.WriteLine("******Demo Consuming Assemblies******");
            //Invoke Add Method
            result = a.Add(b);
            Console.WriteLine($"{a}+{b}={result}");
            //Invoke Sub Method
            result = a.Sub(b);
            Console.WriteLine($"{a}-{b}={result}");
            Console.ReadLine();

        }
    }
}
