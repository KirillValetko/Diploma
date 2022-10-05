using System.ComponentModel.DataAnnotations;

namespace BookingWebApp.Models
{
    public class BookingViewModel : IValidatableObject
    {
        public long? BookingId { get; set; }

        public long? ClientId { get; set; }

        public long? RoomId { get; set; }

        public string? Hotel { get; set; }

        public short? RoomNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckInDate < DateTime.Now.Date)
                yield return new ValidationResult("Check-in date cannot be less than today date", new[] { "CheckInDate" });
            else if(CheckOutDate <= CheckInDate)
                yield return new ValidationResult("Check-out date cannot be less than check-in date or equal to it", new[] { "CheckOutDate" });
        }
    }
}
