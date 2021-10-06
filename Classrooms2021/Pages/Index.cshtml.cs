using Classrooms2021.Data;
using Classrooms2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms2021.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AppDbContext _db;

        public List<Classroom> Classrooms { get; set; }
        public List<Student> Students { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            Classrooms = _db.Classrooms.OrderBy(c => c.Name).ToList();
            Students = _db.Students.Include(s => s.Classroom).OrderBy(s => s.Lastname).ThenBy(s => s.Firstname).ToList();
        }
    }
}
