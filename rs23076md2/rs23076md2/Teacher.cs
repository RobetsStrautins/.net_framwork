using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rs23076md2
{
    class Teacher : Person
    {
        public static List<Teacher> Teachers = new List<Teacher>();
        public DateTime ContractDate { get; set; }
        public Teacher(string name, string surname, MainPage.Gender gender, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            ContractDate = date;

        }
        public override string ToString()
        {
            return (base.ToString() + ", Date:" + ContractDate);
        }
    }
}
