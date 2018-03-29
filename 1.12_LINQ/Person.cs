using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    public class Person
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public char Gender { get; set; }

        public Person(string Name, uint Age, char Gender)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            return String.Format("Name: {0} \nAge: {1} \nGender: {2}", this.Name, this.Age, this.Gender);
        }
    }
}
