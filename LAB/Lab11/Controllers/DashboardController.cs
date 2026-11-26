
using Microsoft.AspNetCore.Mvc;
using SmartCampusPortal.Data;

namespace SmartCampusPortal.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalStudents = _context.Students.Count();
            ViewBag.TotalServices = _context.CampusServices.Count();
            ViewBag.TotalRequests = _context.ServiceRequests.Count();
            ViewBag.PendingRequests = _context.ServiceRequests
                .Count(r => r.Status == "Pending");

            return View();
        }
    }
}
