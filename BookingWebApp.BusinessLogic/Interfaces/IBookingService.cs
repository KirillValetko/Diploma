using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingWebApp.BusinessLogic.Models;

namespace BookingWebApp.BusinessLogic.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings(long clientId);
        void BookTheRoom(long roomId, long clientId, DateTime CheckIn, DateTime CheckOut);
        void CancelBooking(long bookingId);
        IEnumerable<Room> FindUnbookedRooms(int hotelId, DateTime CheckIn, DateTime CheckOut);
        Booking Get(long bookingId);
    }
}
