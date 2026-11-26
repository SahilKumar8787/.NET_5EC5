
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;

namespace SmartCampusPortal.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _context.CampusServices.ToListAsync();
            return View(services);
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _context.CampusServices.FindAsync(id);

            if (service == null)
                return NotFound();

            return View(service);
        }
    }
}
