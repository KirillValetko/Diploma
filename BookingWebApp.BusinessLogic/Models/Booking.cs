using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Models
{
    public class Booking
    {
        public long BookingId { get; set; }
        public long ClientId { get; set; }
        public long RoomId { get; set; }
        public string Hotel { get; set; }
        public short RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsActive { get; set; }

    }
}
