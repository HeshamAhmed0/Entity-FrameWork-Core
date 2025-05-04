using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Models
{
    internal class StudentCourses
    {
        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }
    }
}
