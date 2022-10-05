using System.ComponentModel.DataAnnotations;

namespace BookingWebApp.Models
{
    public class HotelViewModel
    {
        public int? HotelId { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public string? HotelName { get; set; }

        [Required]
        [Display(Name = "Number of rooms")]
        public short NumberOfRooms { get; set; }

        [Required]
        [Display(Name = "Number of floors")]
        public byte NumberOfFloors { get; set; }

        [Required]
        public bool Parking { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? Sity { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public short? Building { get; set; }

        [Display(Name = "Address")]
        public string? Addr { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        public string? EMail { get; set; }

        [Display(Name = "Password")]
        public string? PasswordHash { get; set; }
    }
}
