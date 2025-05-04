using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Models
{
    internal class Department
    {
       public int DepartmentId { get; set; }
       public string DepartmentName { get; set; }
        public ICollection<Constructor> Constructor { get; set; }

        public override string ToString()
        {
            return $"DepartmentId = {DepartmentId} , DepartmentName = {DepartmentName}\n ";
        }
    }
}
