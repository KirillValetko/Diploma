using System;
using System.Collections.Generic;

namespace BookingWebApp.DataAccess.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public short NumberOfRooms { get; set; }
        public byte NumberOfFloors { get; set; }
        public bool Parking { get; set; }
        public string Addr { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
