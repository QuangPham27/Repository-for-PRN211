using System;
using System.Threading;

namespace Thread_Pool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Demo The CoreCLR Thread Pool *****");
            Console.WriteLine("Main thread stated. ThreadID = {0}",
                Thread.CurrentThread.ManagedThreadId);
            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued.");
            Console.ReadLine();
        }
        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
    public class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("->{0} is executing PrintNumbers()", Thread.CurrentThread.ManagedThreadId);
                for (int i = 1; i <= 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(500 * r.Next(5));
                    Console.Write($"{i,3}{(i == 5 ? "" : ",")}");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
