using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Center.ApplicationDbContexts;
using Center.Models;

namespace Center.Transaction
{
    internal class InsertStatemnet
    {
        public void InsertSection()
        {

            Console.Clear();
            Console.WriteLine("1 :: InsertIntoConstructor");
            Console.WriteLine("2 :: InsertIntoDepartment");
            Console.WriteLine("3 :: InsertIntoStudent");
            Console.WriteLine("4 :: InsertIntoCourses");
            Console.WriteLine("5 :: InsertIntoStudentCourses");
            Console.Write("Your Choosen : ");
            int Input = int.Parse(Console.ReadLine());
            Console.Clear();
            if (Input == 1)
            {
                InserConstructor();
            }
            else if (Input == 2)
            {
                InsertDepartment();
            }
            else if (Input == 3)
            {
                InsertStudent();
            }else if (Input == 4)
            {
                InsertCourses();
            }else if (Input == 5)
            {
                InsertIntoStudentCourse();
            }
            else
            {
                Console.WriteLine("You Choosen Is Not Correct Please Choose Correct Choosen");
                InsertSection();
            }


        }
        public void InserConstructor()
        {
            AppDbContext appDbContext = new AppDbContext();


            Console.WriteLine("**********Hellow New Constructor Page**********");

            Console.Write("Enter Constructor Name : ");
            string Name = Console.ReadLine();

            Console.Write("Enter Constructor Salary : ");
            decimal Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Constructor PhoneNumber : ");
            string PhoneNumber = Console.ReadLine();

            Console.Write("Enter Constructor DepartmentId : ");
            int DepartmentId = int.Parse(Console.ReadLine());


            Constructor NewConstructor = new Constructor()
            {
                ConstructorName = Name,
                PhoneNumber = PhoneNumber,
                Salary = Salary,
                DeptId = DepartmentId,
            };
            appDbContext.Add(NewConstructor);
            appDbContext.SaveChanges();


        }

        public void InsertCourses()
        {
            AppDbContext appDbContext = new AppDbContext();
            Console.Write("Enter Course Name : ");
            string CourseName = Console.ReadLine();

            Courses NewCourse = new Courses()
            {
                CourseName = CourseName,
            };
            appDbContext.Courses.Add(NewCourse);
            appDbContext.SaveChanges();
        }

        public void InsertDepartment()
        {
            AppDbContext appDbContext = new AppDbContext();

            Console.Write("Enter Department Name : ");
            string DepartmentName = Console.ReadLine();
            Department NewDepartment = new Department()
            {
                DepartmentName = DepartmentName
            };
            appDbContext.Add(NewDepartment);
            appDbContext.SaveChanges();
        }

        public void InsertStudent()
        {
            AppDbContext appDbContext = new AppDbContext();
            Console.WriteLine("********** Hello In Section Add New Student **********");

            Console.Write("Enter Student Name : ");
            string Name = Console.ReadLine();

            Console.Write("Enter Student Age : ");
            int Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student PhoneNumber : ");
            string Phone = Console.ReadLine();

            Console.Write("Enter Constructor Id : ");
            int ConstructorId = int.Parse(Console.ReadLine());

            Student NewStudent = new Student()
            {
                StudentName = Name,
                StudentAge = Age,
                PhoneNumber = Phone,
                ConstructorId = ConstructorId
            };

            appDbContext.Students.Add(NewStudent);
            appDbContext.SaveChanges();
        }
        public void InsertIntoStudentCourse()
        {
            AppDbContext appDbContext = new AppDbContext();
            
            Console.Write("Enter Student Name : ");
            string  Name = Console.ReadLine();

            Console.Write("Enter Student Age : ");
            int Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade Of Student : ");
            int Grade = int.Parse(Console.ReadLine());
            
            Console.Write("Enter PhoneNumber : ");
            string Number = Console.ReadLine();

            Console.Write("Enter Constructor Id : ");
            int ConstructroId = int.Parse(Console.ReadLine());

            Student newStudent = new Student()
            {
                StudentName = Name,
                StudentAge =Age,
                ConstructorId=ConstructroId,
                PhoneNumber=Number
                

            };
            appDbContext.Students.Add(newStudent);
            appDbContext.SaveChanges();


            Console.Write("Enter Course Title : ");
            string CourseTitle = Console.ReadLine();
            Courses courses = new Courses()
            {
                CourseName = CourseTitle,
            };
            appDbContext.Courses.Add(courses);
            appDbContext.SaveChanges();


            StudentCourses NewStudenCourse = new StudentCourses()
            {
              CourseId=courses.CourseId,
              StudentId=newStudent.StudentId,
              Grade=Grade,
            };
            appDbContext.Set<StudentCourses>().Add(NewStudenCourse);
            appDbContext.SaveChanges();
        }
    }
}
