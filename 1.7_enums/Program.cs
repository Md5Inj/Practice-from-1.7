using System;

namespace _1._7_enums
{
    class Program
    {
        public struct Message {
            public int Num;
            public int ID;
            public string text;
            public string date;
            
            public override string ToString()
            {
                return String.Format($"{Num} {ID} {text} {date}");
            } 

            public void Input()
            {
                Console.Write("Input device num: "); this.Num = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input ID of message: "); this.ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input text: "); this.text = Console.ReadLine();
                Console.Write("Input date of message: "); this.date = Console.ReadLine();
            }
        }

        static void Sort(Message[] arr)
        {
            bool swapped = true;
            int j = 0;
            Message tmp;
            while (swapped) {
                swapped = false;
                j++;
                for (int i = 0; i < arr.Length - j; i++) {
                    if (arr[i].Num > arr[i + 1].Num) {
                        tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        swapped = true;
                    }
                }
            }

            swapped = true; j = 0;
            while (swapped) {
                swapped = false;
                j++;
                for (int i = 0; i < arr.Length - j; i++) {
                    if (arr[i].text[0] > arr[i + 1].text[0]) {
                        tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        swapped = true;
                    }
                }
            }
        }

        static void Print(Message[] m, int year)
        {
            foreach (var item in m)
            {
                if (item.date.IndexOf(year.ToString()) != -1)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Print(Message[] m)
        {
            foreach (var item in m)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Input length of list: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Message[] m = new Message[count];
            for (int i = 0; i < count; i++)
                m[i].Input();
            
            Print(m);
            Sort(m);
            Console.WriteLine("Sorted list: ");
            Print(m);

            Console.Write("input year: ");
            int Year = Convert.ToInt32(Console.ReadLine()); 

            Print(m, Year);

            Console.ReadKey();
        }
    }
}
