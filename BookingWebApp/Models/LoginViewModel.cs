using System.ComponentModel.DataAnnotations;

namespace BookingWebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string? EMail { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
