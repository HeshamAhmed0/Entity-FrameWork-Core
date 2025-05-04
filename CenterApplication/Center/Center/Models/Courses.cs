using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Models
{
    internal class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourses> studentCourses { get; set; }
        //public Student student { get; set; }
    }
}
