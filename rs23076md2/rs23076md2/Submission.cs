using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rs23076md2
{
    class Submission
    {
        public static List<Submission> Submissions = new List<Submission>();
        public Assignement Assignement { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }

        public Submission(Assignement assignement, Student student, DateTime submissionTime, int score)
        {
            Assignement = assignement;
            Student = student;
            SubmissionTime = submissionTime;
            Score = score;
        }
        public override string ToString()
        {
            return (Assignement.ToString() + ", " + Student.ToString() + ", submissionTime:" + SubmissionTime + ", Score:" + Score);
        }
    }
}
