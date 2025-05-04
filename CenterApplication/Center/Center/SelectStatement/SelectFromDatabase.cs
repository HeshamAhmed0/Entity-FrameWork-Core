using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Center.ApplicationDbContexts;
using Microsoft.EntityFrameworkCore;

namespace Center.SelectStatement
{
    internal class SelectFromDatabase
    {
        public  void Select()
        {
            Console.WriteLine("Enter Section You Want To Select From : ");
            Console.WriteLine("1 :: Select From Student ");
            Console.WriteLine("2 :: Select From Department");
            Console.WriteLine("3 :: Select From Constructor");
            Console.Write(" Your Choosen ::=> ");
            int Input = int.Parse(Console.ReadLine());
            Console.Clear();
            if (Input == 1)
            {
                SelectFromStudent();
            }
            else if (Input == 2)
            {
                SelectFromDepartment();
            }
            else if (Input == 3)
            { 
              SelectFromConstructor();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your Choosen Is Not Correct Please Enter New Choosen ");
                Select();
            }
        }

        public  void SelectFromStudent()
        {
            AppDbContext appDbContext = new AppDbContext();

            var Students = appDbContext.Students.Join(appDbContext.Constructors, S => S.ConstructorId, C => C.ConstructorID, (S, C) => new
            {
                StudentId = S.StudentId,
                StudentName = S.StudentName,
                StudentAge = S.StudentAge,
                StudentPhoneNumber = S.PhoneNumber,
                ConstructorId = C.ConstructorID,
                Constructor = C.ConstructorName,
                ConstrucorPhoneNumber = C.PhoneNumber,
            });
            if (Students is not null)
            {
                foreach (var Student in Students)
                {
                    Console.WriteLine(Student);
                }
            }
        }
        public  void SelectFromDepartment()
        {
            AppDbContext appDbContext = new AppDbContext();
           var Departments= appDbContext.Departments.ToList();
           if (Departments is not null)
            {
                foreach (var Department in Departments)
                {
                    Console.WriteLine(Department);
                }
            }


        }
        public  void SelectFromConstructor()
        {
            AppDbContext appDbContext = new AppDbContext();

            var Constructors = appDbContext.Constructors.Join(appDbContext.Departments,C=>C.DeptId,D => D.DepartmentId,
                                                              (C , D)=> new
                                                              {
                                                                  ConstructorId =C.ConstructorID,
                                                                  ConstructorName =C.ConstructorName,
                                                                  ConstructorPhoneNumber =C.PhoneNumber,
                                                                  DepartmentId =D.DepartmentId,
                                                                  DepartmentName =D.DepartmentName,
                                                              });
           if(Constructors is not null)
            {
                foreach (var Constructor in Constructors)
                {
                    Console.WriteLine(Constructor);
                }
            }
        }
    }
}
