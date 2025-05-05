using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.DbContexts
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = Library Management System ;Trusted_Connection = true ;TrustServerCertificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasOne(D => D.Department)
                                       .WithMany(B => B.Books)
                                       .HasForeignKey(BD => BD.DepartmentId);


            modelBuilder.Entity<Person>().HasOne(Person => Person.Books)
                                         .WithMany(B => B.Person)
                                         .HasForeignKey(PB => PB.BookId);

            modelBuilder.Entity<Book>().HasKey(K => K.BookNumber);

            modelBuilder.Entity<Department>().HasKey(D => D.DepartmentNumber);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
