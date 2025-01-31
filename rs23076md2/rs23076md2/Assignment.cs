using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using rs23076md2;

namespace rs23076md2
{
    class Assignement
    {
        public static List<Assignement> Assignments = new List<Assignement>();
        public DateTime Deadline { get; set; }
        public Course Course { get; set; }
        public string Description { get; set; }

        public Assignement(DateTime deadline, Course course, string description)
        {
            Deadline = deadline;
            Course = course;
            Description = description;
        }

        public override string ToString()
        {
            return ("Deadline: " + Deadline + ", " + Course.ToString() + ", Description:" + Description);
        }
    }
}
