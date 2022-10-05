using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Models
{
    public class Client
    {
        public long ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string? PasswordHash { get; set; }

    }
}
