
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<CampusService> CampusServices { get; set; }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
