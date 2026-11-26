
using System.ComponentModel.DataAnnotations;

namespace SmartCampusPortal.Models
{
    public class CampusService
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
