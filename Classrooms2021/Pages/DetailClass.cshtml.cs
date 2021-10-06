using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Classrooms2021.Data;
using Classrooms2021.Models;

namespace Classrooms2021.Pages
{
    public class DetailClassModel : PageModel
    {
        private readonly Classrooms2021.Data.AppDbContext _context;

        public DetailClassModel(Classrooms2021.Data.AppDbContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }
        public List<Student> Students { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.Id == id);

            if (Classroom == null)
            {
                return NotFound();
            }

            Students = await _context.Students
                .Where(s => s.ClassroomId == Classroom.Id)
                .OrderBy(s => s.Lastname).ThenBy(s => s.Firstname)
                .ToListAsync();
            return Page();
        }
    }
}
