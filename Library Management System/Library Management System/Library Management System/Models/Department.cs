using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Department
    {
        public int DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }


        #region RelationShip Between Department And Books
        public ICollection<Book> Books { get; set; }
        #endregion


        public override string ToString()
        {
            return $"Department Id : {DepartmentNumber} , Department Name : {DepartmentName}";
        }
    }
}
