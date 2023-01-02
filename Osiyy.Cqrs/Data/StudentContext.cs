using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osiyy.Cqrs.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]{
new Student(){Name="Nihal",Age=33,Surname="öz",Id=1},
new Student(){Name="Akın",Age=33,Surname="öz",Id=2}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
