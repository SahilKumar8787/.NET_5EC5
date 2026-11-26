
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetRequests()
        {
            return await _context.ServiceRequests
                .Include(r => r.Student)
                .Include(r => r.CampusService)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetRequest(int id)
        {
            var request = await _context.ServiceRequests
                .Include(r => r.Student)
                .Include(r => r.CampusService)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
                return NotFound();

            return request;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> CreateRequest(ServiceRequest request)
        {
            request.RequestDate = DateTime.Now;
            request.Status = "Pending";

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRequest),
                new { id = request.RequestId }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, ServiceRequest request)
        {
            if (id != request.RequestId)
                return BadRequest();

            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            _context.ServiceRequests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
