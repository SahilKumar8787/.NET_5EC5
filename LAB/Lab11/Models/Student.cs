
using System.ComponentModel.DataAnnotations;

namespace SmartCampusPortal.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Course { get; set; } = string.Empty;

        [Range(1, 12)]
        public int Semester { get; set; }
    }
}
