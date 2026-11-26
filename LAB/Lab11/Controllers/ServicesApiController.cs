
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampusService>>> GetServices()
        {
            return await _context.CampusServices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampusService>> GetService(int id)
        {
            var service = await _context.CampusServices.FindAsync(id);

            if (service == null)
                return NotFound();

            return service;
        }

        [HttpPost]
        public async Task<ActionResult<CampusService>> CreateService(CampusService service)
        {
            _context.CampusServices.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetService),
                new { id = service.ServiceId }, service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, CampusService service)
        {
            if (id != service.ServiceId)
                return BadRequest();

            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.CampusServices.FindAsync(id);

            if (service == null)
                return NotFound();

            _context.CampusServices.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
