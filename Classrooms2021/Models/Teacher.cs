using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms2021.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Classroom> Classrooms { get; set; }
    }
}
