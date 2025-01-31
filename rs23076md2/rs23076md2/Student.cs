using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rs23076md2
{
    class Student : Person
    {
        public static List<Student> Students = new List<Student>();
        public string StudentIdNumder { get; set; }

        public Student(string name, string surname, MainPage.Gender gender, string ID)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            StudentIdNumder = ID;
        }
        public Student(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return (base.ToString() + ", ID:" + StudentIdNumder);
        }
    }
}
