using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Classrooms2021.Data;
using Classrooms2021.Models;

namespace Classrooms2021.Pages
{
    public class CreateStudentModel : PageModel
    {
        private readonly Classrooms2021.Data.AppDbContext _context;

        public CreateStudentModel(Classrooms2021.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Name");
            Classrooms = new SelectList(_context.Classrooms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        public SelectList Classrooms { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
