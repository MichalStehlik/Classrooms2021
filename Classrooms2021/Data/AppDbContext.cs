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
            mb.Entity<Classroom>().HasData(new Classroom { Id = 1, Name = "P3"});
            mb.Entity<Classroom>().HasData(new Classroom { Id = 2, Name = "P4" });
        }
    }
}
