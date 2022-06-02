using System;
using System.Threading;

namespace Thread_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";
            Console.WriteLine($"ID of current thread: { primaryThread.ManagedThreadId}");
            Console.WriteLine($"Thread Name: {primaryThread.Name}");
            Console.WriteLine($"Has thread started?: {primaryThread.IsAlive}");
            Console.WriteLine($"Priority Level: {primaryThread.Priority}");
            Console.WriteLine($"Thread State: {primaryThread.ThreadState}");
            Console.ReadLine();
        }
    }
}
