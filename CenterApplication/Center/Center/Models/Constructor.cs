using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Models
{
    internal class Constructor
    {
        public int ConstructorID { get; set; }
        public string ConstructorName { get; set; }
        public decimal Salary { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
