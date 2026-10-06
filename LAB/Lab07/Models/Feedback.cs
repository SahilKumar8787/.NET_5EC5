using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a rating.")]
        [Display(Name = "Rating")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Please enter your feedback.")]
        [StringLength(500, ErrorMessage = "Feedback cannot exceed 500 characters.")]
        [Display(Name = "Your Feedback")]
        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}