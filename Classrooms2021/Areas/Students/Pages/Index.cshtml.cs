using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Classrooms2021.Data;
using Classrooms2021.Models;

namespace Classrooms2021.Areas.Students.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Classrooms2021.Data.AppDbContext _context;

        public IndexModel(Classrooms2021.Data.AppDbContext context)
        {
            _context = context;
        }

        public List<Student> Student { get;set; }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public void OnGet(string classname)
        {
            IQueryable<Student> students = _context.Students;
            if (!String.IsNullOrEmpty(Search))
            {
                students = students.Where(s => (s.Firstname.Contains(Search) || (s.Lastname.Contains(Search))));
            }
            Student = students
                .Include(s => s.Classroom)
                .ToList();
        }
    }
}
