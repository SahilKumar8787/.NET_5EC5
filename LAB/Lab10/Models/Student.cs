using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enrollment number is required")]
        [StringLength(25)]
        public string EnrollmentNo { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Department { get; set; } = string.Empty;

        [Range(1, 8)]
        public int Semester { get; set; }
    }
}