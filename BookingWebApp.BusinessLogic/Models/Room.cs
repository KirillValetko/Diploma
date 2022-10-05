using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Models
{
    public class Room
    {
        public long RoomId { get; set; }
        public int HotelId { get; set; }
        public short RoomNumber { get; set; }
        public byte FloorNumber { get; set; }
        public byte NumberOfBedrooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public bool IsLuxe { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
