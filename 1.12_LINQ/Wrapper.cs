using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wrapper
{
    public class Wrapper : IEnumerable
    {
        private LinkedList<Person> List;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.List.GetEnumerator();
        }
        public Wrapper() // Default constructor
        {
            List = new LinkedList<Person>();
            this.LoadFromFile("Info");
        }

        public void Insert(Person p) // Inserting element into end of list
        {
            List.AddLast(p);
        }

        public void Remove()
        {
            List.Remove(List.First);
        }

        public void Change(Person what, Person whom)
        {
            List.Find(what).Value = whom;
        }

        public Person GetValue()
        {
            return List.First.Value;
        }

        public LinkedListNode<Person> GetFirst()
        {
            return List.First;
        }

        public LinkedListNode<Person> GetLast()
        {
            return List.Last;
        }

        public void Print()
        {
            int count = 0;
            foreach (var item in List)
            {
                Console.WriteLine("{0}:", count++);
                Console.WriteLine("name: {0}", item.Name);
                Console.WriteLine("age: {0}", item.Age);
                Console.WriteLine("gender: {0}", item.Gender);
            }
        }

        public LinkedListNode<Person> GetNext(LinkedListNode<Person> now)
        {
            return now.Next;
        }

        public LinkedListNode<Person> GetPrev(LinkedListNode<Person> now)
        {
            return now.Previous;
        }

        public void LoadFromFile(String fileName)
        {
            this.List.Clear();
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            String line = "", age = "", gender = "";

            while (true)
            {
                line = reader.ReadLine();
                if (line == null) break;
                age = reader.ReadLine();
                gender = reader.ReadLine();
                this.Insert(new Person(line, Convert.ToUInt32(age), gender[0]));
            }

            reader.Close();
        }

        public void SaveToFile(String filename)
        {
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            foreach (var item in List)
            {
                writer.WriteLine(item.Name);
                writer.WriteLine(item.Age);
                writer.WriteLine(item.Gender);
            }
            writer.Close();
        }

        public Person GetFromIndex(int index)
        {
            int count = 0;
            foreach (var item in List)
            {
                if (count == index) return item;
                count++;
            }
            return null;
        }

        public IOrderedEnumerable<Person> Choice(int age)
        {
            return from t in this.List where t.Age == age orderby t.Name select t;
        }

        public IEnumerable<uint> SelectName(string name)
        {
            return from t in this.List where t.Name == name orderby t.Name select t.Age;
        }

        public IEnumerable<string> GetNames()
        {
            return from t in this.List select t.Name;
        }

        public IEnumerable<string> ManySelect(string gender, int age)
        {
            return from t in this.List where (t.Gender == gender[0] && t.Age == age) select t.Name;
        }

        public IEnumerable<Person> SortForAge()
        {
            return from t in this.List orderby t.Age select t;
        }

        public int SumAge()
        {
            return (int)this.List.Sum(n => n.Age);
        }

        public double AverageSum()
        {
            return this.List.Average(n => n.Age);
        }

        public uint MaxAge()
        {
            return this.List.Max(n => n.Age);
        }

        public uint MinAge()
        {
            return this.List.Min(n => n.Age);
        }

        public IEnumerable<IGrouping<uint, Person>> GroupByAge()
        {
            return from t in this.List group t by t.Age;
        }

        public IEnumerable<Person> Union()
        {
            var temp = this.List;
            temp.AddLast(new Person() { Name = "Keks", Age = 19, Gender = 'M' });
            return this.List.Union(temp);
        }
    }
}
