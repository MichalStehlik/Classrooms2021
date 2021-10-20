using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classrooms2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Classrooms2021.Areas.Students.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Classrooms2021.Data.AppDbContext _context;

        public CreateModel(Classrooms2021.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Name");
            Classrooms = new SelectList(_context.Classrooms, "Id", "Name");
            Classrooms2 = new List<SelectListItem>();
            foreach(var item in _context.Classrooms)
            {
                Classrooms2.Add(new SelectListItem { Text = item.Name + " (X)", Value = item.Id.ToString()});
            }
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        public SelectList Classrooms { get; set; }
        public List<SelectListItem> Classrooms2 { get; set; }

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
