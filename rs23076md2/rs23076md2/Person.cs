using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rs23076md2;

namespace rs23076md2
{

    abstract class Person
    {
        private string Name, Surname;
        public string name
        {
            get { return Name; }
            set
            {
                if (value != "")
                    Name = value;
            }
        }

        public string surname
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public string Fullname()
        {
            return (Name + " " + Surname);
        }

        public MainPage.Gender gender { get; set; }

        public override string ToString()
        {
            return ("Name:" + Name + ", Surname:" + Surname + ", Gender:" + gender);
        }

    }
}
