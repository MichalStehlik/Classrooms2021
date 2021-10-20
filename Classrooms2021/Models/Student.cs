using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms2021.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        public string Lastname { get; set; }
        public int ShoeSize { get; set; }   
        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; } // Navigation property
        [Required]
        public int ClassroomId { get; set; }
    }
}
