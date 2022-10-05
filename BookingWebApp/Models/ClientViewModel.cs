using System.ComponentModel.DataAnnotations;

namespace BookingWebApp.Models
{
    public class ClientViewModel
    {
        public long? ClientId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string? EMail { get; set; }

        [Display(Name = "Password")]
        public string? PasswordHash { get; set; }
    }
}
