using System;

namespace OOP_interface_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.Display();
            IFirst first = obj;
            first.Print();
            ISecond second = obj;
            second.Print();
            Console.ReadLine();
        }
    }
    public interface IFirst
    {
        void Print();
        void Display();
    }
    public interface ISecond
    {
        void Print();
    }
    public class MyClass : IFirst, ISecond
    {
        public void Display()
        {
            Console.WriteLine("Display Method");
        }
        void IFirst.Print()
        {
            Console.WriteLine("IFirst's Print Method");
        }
        void ISecond.Print()
        {
            Console.WriteLine("ISecond's Print Method");
        }
    }
}
