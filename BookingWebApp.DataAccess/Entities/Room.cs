using System;
using System.Collections.Generic;

namespace BookingWebApp.DataAccess.Entities
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public long RoomId { get; set; }
        public int HotelId { get; set; }
        public short RoomNumber { get; set; }
        public byte FloorNumber { get; set; }
        public byte NumberOfBedrooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public bool IsLuxe { get; set; }
        public decimal PricePerDay { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
