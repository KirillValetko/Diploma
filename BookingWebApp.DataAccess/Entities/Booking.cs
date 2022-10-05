using System;
using System.Collections.Generic;

namespace BookingWebApp.DataAccess.Entities
{
    public partial class Booking
    {
        public long BookingId { get; set; }
        public long ClientId { get; set; }
        public long RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
