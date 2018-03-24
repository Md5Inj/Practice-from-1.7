using System;

namespace _1._9_delegates_threads
{
    class Chief
    {
        public Chief(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public void createTask(object sender, TimeIsStartEventArgs e)
        {
            Console.WriteLine($"{e.Name}, выполните мне это задание: {e.Message}");
        }
    }
}