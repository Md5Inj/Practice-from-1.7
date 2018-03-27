using System;
using System.Threading;

namespace _1._9_delegates_threads
{
    class Program
    {
        static string ShowMessage(string msg)
        {
            Console.WriteLine(msg);
            return msg;
        }

        static void Main(string[] args)
        {
            Console.Write("Input the timeout: ");
            Clock c = new Clock(Convert.ToInt32(Console.ReadLine()));
            Worker w = new Worker("Максик");
            Chief chief = new Chief("Санчо");
            c.TimeStart += chief.createTask;
            c.TimeOver += w.WorkDone;

            c.Start("Поставить системный блок на УВЦ", w.Name, chief.Name);
            Console.Read();
        }
    }
}