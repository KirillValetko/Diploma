using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWebApp.Models
{
    public class RoomViewModel
    {
        public long? RoomId { get; set; }
        public int? HotelId { get; set; }

        [Required]
        [Display(Name = "Room number")]
        public short? RoomNumber { get; set; }

        [Required]
        [Display(Name = "Floor number")]
        public byte FloorNumber { get; set; }

        [Required]
        [Display(Name = "Number of bedrooms")]
        public byte NumberOfBedrooms { get; set; }

        [Required]
        [Display(Name = "Number of beds")]
        public byte NumberOfBeds { get; set; }

        [Required]
        [Display(Name = "Luxe")]
        public bool IsLuxe { get; set; }

        [Required]
        [Display(Name = "Price per day")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerDay { get; set; }
    }
}
