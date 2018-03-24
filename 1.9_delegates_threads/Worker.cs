using System;

namespace _1._9_delegates_threads
{
    class Worker
    {
        public Worker(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public void WorkDone(object sender, TimeIsOverEventArgs e)
        {
            Console.WriteLine($"{e.Name}, ваше задание \"{e.Message}\" выполнено!");
        }
    }
}