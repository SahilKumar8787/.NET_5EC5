
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;

namespace SmartCampusPortal.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _context.ServiceRequests
                .Include(r => r.Student)
                .Include(r => r.CampusService)
                .ToListAsync();

            return View(requests);
        }

        public async Task<IActionResult> Details(int id)
        {
            var request = await _context.ServiceRequests
                .Include(r => r.Student)
                .Include(r => r.CampusService)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
                return NotFound();

            return View(request);
        }
    }
}
