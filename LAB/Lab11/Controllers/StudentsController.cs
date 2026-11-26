
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;

namespace SmartCampusPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}
