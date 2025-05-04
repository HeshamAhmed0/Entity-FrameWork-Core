using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }



      
        //public int CourseId { get; set; }
        //public ICollection<Courses> courses { get; set; }



        [ForeignKey(nameof(Constructor))]
        public int ConstructorId { get; set; }
        public Constructor Constructor {  get; set; }


        public ICollection<StudentCourses> StudentCourses { get; set; }
        
    }
}
