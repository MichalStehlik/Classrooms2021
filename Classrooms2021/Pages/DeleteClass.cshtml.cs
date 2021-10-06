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
    public class DeleteClassModel : PageModel
    {
        private readonly Classrooms2021.Data.AppDbContext _context;

        public DeleteClassModel(Classrooms2021.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Classroom Classroom { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classrooms.FindAsync(id);

            if (Classroom != null)
            {
                _context.Classrooms.Remove(Classroom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
