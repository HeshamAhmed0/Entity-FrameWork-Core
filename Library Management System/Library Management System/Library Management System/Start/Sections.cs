using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.DbContexts;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace Library_Management_System.Start
{
    internal class Sections
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        #region Insert Section 
        private void InsertIntoDepartment()
        {
            Console.Clear();
            Console.Write("Enter DepartmentName : ");
            string DepartmentName = Console.ReadLine();
            Console.Clear();
            Department NewDepartment = new Department()
            {
                DepartmentName = DepartmentName,
            };
            dbContext.Departments.Add(NewDepartment);
            dbContext.SaveChanges();
            
        }
        private void InsertIntoBooks()
        {
            Console.Clear();
            Console.Write("Enter Book Name : ");
            string BookName = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter Book Price : ");
            decimal Salary = decimal.Parse(Console.ReadLine());
            Console.Clear();
            foreach (var item in dbContext.Departments)
            {
                Console.WriteLine(item);
            }
            Console.Write("Enter Department Number : ");
            int DepartmentNumber =int.Parse(Console.ReadLine());
            Book NewBook = new Book()
            {
                BookName = BookName,
                BookSalary = Salary,
                DepartmentId = DepartmentNumber,
            };
            dbContext.Books.Add(NewBook);
            dbContext.SaveChanges();
        }

        private void InsertIntoPerson()
        {
            Console.Clear();

            Console.Write("Enter Person Name : ");
            string Name = Console.ReadLine();
            Console.Clear();
            int BookId=0;
            bool PersonResult=false;
           while (PersonResult==false)
            {
                Console.Write("Enter Book Id : ");
                 BookId = int.Parse(Console.ReadLine());
                foreach (var book in dbContext.Books)
                {
                    if (book.BookNumber == BookId)
                    {
                       PersonResult = true;
                        continue;
                    }
                  
                }
                if (PersonResult==false)
                {
                    Console.WriteLine("BookId id not Correct");

                }


            }

            Person NewPerson = new Person()
            {
                Name = Name,
                DateTime = DateTime.Now,
                BookId = BookId,
            };
            dbContext.Persons.Add(NewPerson);
            dbContext.SaveChanges();

        }
        #endregion

        #region Delete Section 
        private void RemoveFromPerson()
        {
            Console.Clear();
            Console.Write("Enter Person Name Do You Want To Remove it : ");
            string PersonName = Console.ReadLine();
            var DleteFromPerson = dbContext.Persons.Where(C => C.Name == PersonName).FirstOrDefault();
            if (DleteFromPerson is not null)
            {
                dbContext.Persons.Remove(DleteFromPerson);
                dbContext.SaveChanges();
            }
        }

        private void RemoveFromBooks()
        {
            Console.Clear();
            Console.Write("Enter Book Name Do You Want To Delete It : ");
            string NameOfBook =Console.ReadLine();
            var DeleteFromBooks = dbContext.Books.Where(N => N.BookName == NameOfBook).FirstOrDefault();
            if (DeleteFromBooks is not null)
            {
                dbContext.Books.Remove(DeleteFromBooks);
                dbContext.SaveChanges();
            }
        }

        private void RemoveFromDepartment()
        {
            Console.Clear();
            Console.Write("Enter Department Name Do You Want To Delete It : ");
            string NameOfDepartment =Console.ReadLine();
            var DeleteFromDepartment=dbContext.Departments.Where(N => N.DepartmentName == NameOfDepartment).FirstOrDefault();
            if (DeleteFromDepartment is not null)
            {
                dbContext.Departments.Remove(DeleteFromDepartment);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region SelectSection
        int Input;
        private void SelectFromBooks()
        {
            Console.Clear();

            Console.WriteLine("Do You Need To Select All Books ");
            Console.Write("1 : Yes  &&  2 : No  ");
             Input = int.Parse(Console.ReadLine());
            if (Input == 1)
            {
                var Result = dbContext.Books.Join(dbContext.Departments,
                                                 B => B.DepartmentId,
                                                 D => D.DepartmentNumber,
                                                 (B, D) => new
                                                 {
                                                     BookId =B.BookNumber,
                                                     BookName =B.BookName,
                                                     BookSalary =B.BookSalary,
                                                     BookDepartment=D.DepartmentName,
                                                 });
                foreach(var  item in Result)
                {
                    Console.WriteLine(item);
                }
            }
            if(Input == 2)
            {
                Console.Write("Enter Name Of Book You Need : ");
                string NameOfBook = Console.ReadLine();
                Console.Clear();
              foreach(var item in  dbContext.Books)
                {
                    if (item.BookName == NameOfBook)
                    {
                        Console.WriteLine(item);
                    }
                    else
                    {
                        Console.WriteLine("This Book Not Founded ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your Input Is Not Correct .");
            }
            
        } 

        private void SelectFromDepartment()
        {
            Console.Clear();

            Console.WriteLine("Do You Need To Select All Department ");
            Console.Write("1 : Yes  &&  2 : No  ");
             Input = int.Parse(Console.ReadLine());
             if(Input == 1)
            {
                foreach(var item in dbContext.Departments)
                {
                    Console.WriteLine(item);
                }
            }
            else if(Input == 2)
            {
                Console.Write("Enter Id For Department You Need : ");
                Input=int.Parse(Console.ReadLine());
                foreach (var item in dbContext.Departments)
                {
                    if (item.DepartmentNumber==Input)
                    {
                        Console.WriteLine(item);
                    }
                    else
                    {
                        Console.WriteLine("Id Is Not Correct");
                    }
                }
            }
        }

        private void SelectFromPerson()
        {
            Console.Clear();

            Console.WriteLine("Do You Need To Select All Persons ");
            Console.Write("1 : Yes  &&  2 : No  ");
            Input = int.Parse(Console.ReadLine());
            if(Input == 1)
            {
                var Result03 = dbContext.Persons.Join(dbContext.Books,
                                                     C => C.BookId,
                                                     B => B.BookNumber,
                                                     (C, B) => new
                                                     {
                                                         Id = C.Id,
                                                         Name = C.Name,
                                                         TimeOfBorrowBook =C.DateTime,
                                                         BookName=B.BookName,
                                                     });

                foreach (var item in Result03)
                {
                    Console.WriteLine(item);
                }
                
            }
        }
        #endregion

        #region Start
        public void Action()
        {
            Sections sections = new Sections();

            Console.WriteLine("1 : Select From Database");
            Console.WriteLine("2 : Insert Into Database");
            Console.WriteLine("3 : Delete From Database");
            Console.Write("What Do You Want : ");
            int ChoosenForSection = int.Parse(Console.ReadLine());
            if (ChoosenForSection == 1)
            {
                Console.WriteLine("1 : Select From Person");
                Console.WriteLine("2 : Select From Department");
                Console.WriteLine("3 : Select From Books");
                Console.Write("What Do You Want : ");
                int ChoosenForSelect = int.Parse(Console.ReadLine());
                if (ChoosenForSelect == 1)
                {
                    sections.SelectFromPerson();
                }
                else if (ChoosenForSelect == 2)
                {
                    sections.SelectFromDepartment();
                }
                else if (ChoosenForSelect == 3)
                {
                    sections.SelectFromBooks();
                }
                else
                {
                    Console.WriteLine("Your Decision Is Not Correct ");
                }

            }
            else if (ChoosenForSection == 2)
            {
                Console.WriteLine("1 : Insert Into Person");
                Console.WriteLine("2 : Insert Into Books ");
                Console.WriteLine("3 : Insert Into Department");
                int ChoosenForInsert = int.Parse(Console.ReadLine());
                if (ChoosenForInsert == 1)
                {
                    sections.InsertIntoPerson();
                }
                else if (ChoosenForInsert == 2)
                {
                    sections.InsertIntoBooks();
                }
                else if (ChoosenForInsert == 3)
                {
                    sections.InsertIntoDepartment();
                }
                else
                {
                    Console.WriteLine("Your Choosen Is Not Correct ");
                }

            }
            else if (ChoosenForSection == 3)
            {
                Console.WriteLine("1 : Remove From Person");
                Console.WriteLine("2 : Remove From Books");
                Console.WriteLine("3 : Remove From Department");
                Console.Write("Your Choosen : ");
                int RemoveChoosen = int.Parse(Console.ReadLine());
                if (RemoveChoosen == 1)
                {
                    sections.RemoveFromPerson();
                }
                else if (RemoveChoosen == 2)
                {
                    sections.RemoveFromBooks();
                }
                else if (RemoveChoosen == 3)
                {
                    sections.RemoveFromDepartment();
                }
                else
                {
                    Console.WriteLine("Your Choosen Is Not Correct");
                }

            }
            else
            {
                Console.WriteLine("Your Choosen Is Not Correct");

            }
            AnotherAction();
        }
        #endregion

        #region Another Action
        private void AnotherAction()
        {
            Console.WriteLine("Do You Need Anothe Action ");
            Console.WriteLine("  1 : Yes    &&    2 : No ");
            Console.Write("Your decision : ");
            int ChoosenForAnotheAction = int.Parse(Console.ReadLine());
            Console.Clear();
            if (ChoosenForAnotheAction == 1)
            {

                Action();

            }
            else if (ChoosenForAnotheAction == 2)
            {
                Console.WriteLine("I Am Happy To Meet You");
            }
            else
            {
                Console.WriteLine("Your Decision Is Not Correct");
                AnotherAction();
            }
        }
        #endregion
    }
}
