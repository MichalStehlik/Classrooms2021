using Classrooms2021.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms2021.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            // -- seed --
            Classroom c1 = new Classroom { Id = 1, Name = "P3" };
            mb.Entity<Classroom>().HasData(c1);
            //mb.Entity<Classroom>().HasData(new Classroom { Id = 1, Name = "P3"});
            mb.Entity<Classroom>().HasData(new Classroom { Id = 2, Name = "P4" });
            mb.Entity<Student>().HasData(new Student { Id = 1, Firstname = "Adam", Lastname="Antl", ShoeSize=42, ClassroomId=1 });
            mb.Entity<Student>().HasData(new Student { Id = 2, Firstname = "Břetislav", Lastname = "Bohatý", ShoeSize = 40, ClassroomId = c1.Id });
        }
    }
}
