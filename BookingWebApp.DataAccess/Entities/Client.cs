using System;
using System.Collections.Generic;

namespace BookingWebApp.DataAccess.Entities
{
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
        }

        public long ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
