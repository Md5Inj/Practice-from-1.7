using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    class MyApplication
    {
        public MyApplication()
        {
            ConsoleKeyInfo key;
            Wrapper wr = new Wrapper();
            String name = "", age = "", gender = "";
            int choice = 0;

            do
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add the person object info list");
                Console.WriteLine("2 - Aggregate operations");
                Console.WriteLine("3 - GroupBy and Union");
                Console.WriteLine("4 - Replace the entered element");
                Console.WriteLine("5 - Multiple selection");
                Console.WriteLine("6 - Sort for age and Get names");
                Console.WriteLine("7 - Print the list");
                Console.WriteLine("8 - Filter for age");
                Console.WriteLine("9 - Select names");

                key = Console.ReadKey();
                
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Input name: "); name = Console.ReadLine();
                        Console.Write("Input age: "); age = Console.ReadLine();
                        Console.Write("Input gender (M - male, F - female): "); gender = Console.ReadLine();
                        wr.Insert(new Person(name, Convert.ToUInt32(age), gender[0]));
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("Input operation ( + - * / ):"); char s = Console.ReadLine()[0];
                        switch (s)
                        {
                            case '+':
                                Console.WriteLine("Age sum: {0}", wr.SumAge()); 
                                break;
                            case '-':
                                Console.WriteLine("Average sum: {0}", wr.AverageSum());
                                break;
                            case '*':
                                Console.WriteLine("Max age: {0}", wr.MaxAge());
                                break;
                            case '/':
                                Console.WriteLine("Min age: {0}", wr.MinAge());
                                break;

                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("GroupBy or Union (0, 1)? ");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        int count = 0;
                        switch (choice1)
                        {
                            case 0:
                                foreach(var item in wr.GroupByAge())
                                {
                                    Console.WriteLine(count++ + ": ");
                                    foreach (var itemI in item)
                                    {
                                        Console.WriteLine(itemI);   
                                    }
                                }
                                break;
                            case 1:
                                foreach (var item in wr.Union())
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.Write("Input the index of replacement element: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input name: "); name = Console.ReadLine();
                        Console.Write("Input age: "); age = Console.ReadLine();
                        Console.Write("Input gender (M - male, F - female): "); gender = Console.ReadLine();
                        wr.Change(wr.GetFromIndex(choice), new Person(name, Convert.ToUInt32(age), gender[0]));
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("Input age and gender: ");
                        age = Console.ReadLine(); gender = Console.ReadLine();
                        foreach (var item in wr.ManySelect(gender, Convert.ToInt32(age)))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.Write("Sort for age or get names (0, 1)? ");
                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        switch (choice2)
                        {
                            case 0:
                                foreach (var item in wr.SortForAge())
                                    Console.WriteLine(item);
                                break;
                            case 1:
                                foreach (var item in wr.GetNames())
                                    Console.WriteLine(item);
                                break;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        wr.Print();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.Write("Input age: "); age = Console.ReadLine();
                        foreach (var item in wr.Choice(Convert.ToInt32(age)))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.Write("Input name: "); name = Console.ReadLine();
                        foreach (var item in wr.SelectName(name))
                        {
                            Console.WriteLine("Name: {0} \nAge: {1}\n", name, item);
                        }
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (key.KeyChar != '0');
        }
    }
}
