using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Center.ApplicationDbContexts;

namespace Center.RemoveStatement
{
    internal class RemoveFromDataBase
    {
        AppDbContext appDbContext=new AppDbContext();
        public void Decition()
        {
            Console.Clear();
            Console.WriteLine("********** Hello IN Remove Section **********");
            Console.WriteLine("1 :: Rmove From Student");
            Console.WriteLine("2 :: Remove From Department");
            Console.WriteLine("3 :: Remove From Constructor");
            Console.Write("You Choosen Is : ");
            int Input =int.Parse(Console.ReadLine());
            Console.Clear();
            if (Input == 1)
            {
                RemoveFromStudent();
            }
            else if (Input == 2)
            {
                RemovefromDepartment();
            }else if ( Input==3)
            {
                RemoveFromConstructor();
            }else
            {
                Console.WriteLine("Your Choosen Is Not Correct Please Enter Correct Choosen ");
                Decition();
            }
        }
        public void RemoveFromStudent()
        {
            Console.Write("Enter StudentId You Want To Remove : ");
            int Input = int.Parse(Console.ReadLine());
            var DeleteStudent=appDbContext.Students.Where(S=>S.StudentId==Input).FirstOrDefault();
            if (DeleteStudent!=null)
            {
                appDbContext.Students.Remove(DeleteStudent);
                appDbContext.SaveChanges();
            }
        }
        public void RemovefromDepartment()
        {
            Console.Write("Enter DepartmentId You Want To Remove : ");
            int Input = int.Parse(Console.ReadLine());
            var RemoveDepartment = appDbContext.Departments.Where(D => D.DepartmentId == Input).FirstOrDefault();

            if (RemoveDepartment != null)
            {
                appDbContext.Departments.Remove(RemoveDepartment);
                appDbContext.SaveChanges();
            }
        }
        public void RemoveFromConstructor()
        {
            Console.Write("Enter ConstructorId You Want To delete It : ");
            int input = int.Parse(Console.ReadLine());
            var DeletedConstructor = appDbContext.Constructors.Where(C => C.ConstructorID == input).FirstOrDefault();
            if (DeletedConstructor != null)
            { 
            appDbContext.Constructors.Remove(DeletedConstructor);
                appDbContext.SaveChanges();
            }
        }


    }
}
