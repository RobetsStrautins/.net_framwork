using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rs23076md2;


namespace rs23076md2
{
    class Course
    {
        public static List<Course> Courses = new List<Course>();
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public Course(string course, Teacher teacher)
        {
            Name = course;
            Teacher = teacher;
        }

        public override string ToString()
        {
            return "Course: " + Name + ", Teachers " + Teacher.ToString();
        }
        public string GetCourseName()
        {
            return Name;
        }


    }
}
