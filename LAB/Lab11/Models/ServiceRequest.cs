
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampusPortal.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        [ForeignKey("ServiceId")]
        public CampusService? CampusService { get; set; }
    }
}
