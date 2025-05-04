using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Center.Models;
using Microsoft.EntityFrameworkCore;

namespace Center.ApplicationDbContexts
{
    internal class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = CodeTitans ;Trusted_Connection = true ;TrustServerCertificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Constructor>().HasOne(E => E.Department)
                                              .WithMany(D => D.Constructor)
                                              .HasForeignKey(D => D.DeptId);

            modelBuilder.Entity<Student>().HasOne(C => C.Constructor)
                                          .WithMany(S => S.Students)
                                          .HasForeignKey(C => C.ConstructorId);

            modelBuilder.Entity<StudentCourses>().HasKey(SC=>new { SC.CourseId,SC.StudentId});
            
            modelBuilder.Entity<StudentCourses>().HasOne(C=>C.Courses)
                                                 .WithMany(SC =>SC.studentCourses)
                                                 .HasForeignKey(C=>C.CourseId);

            modelBuilder.Entity<StudentCourses>().HasOne(S => S.Student)
                                                 .WithMany(SC=>SC.StudentCourses)
                                                 .HasForeignKey(S=>S.StudentId);

            //modelBuilder.Entity<Student>().HasMany(C => C.courses)
            //                              .WithOne(S => S.student)
            //                              .HasForeignKey(S => S.CourseId);
                                        

        }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Courses> Courses { get; set; }
    }
}
