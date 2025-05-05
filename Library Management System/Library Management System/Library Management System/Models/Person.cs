using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }



        #region RelationShip Between Person And Book 
        public int BookId { get; set; }
        public Book Books { get; set; }
        #endregion

        //public override string ToString()
        //{
        //    return $"Id : {Id} , Name : {Name} , DateTime : {DateTime}";
        //}

    }
}
