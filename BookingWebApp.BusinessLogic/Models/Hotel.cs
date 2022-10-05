using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public short NumberOfRooms { get; set; }
        public byte NumberOfFloors { get; set; }
        public bool Parking { get; set; }
        public string Addr { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string? PasswordHash { get; set; }

    }
}
