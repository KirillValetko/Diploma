using BookingWebApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Interfaces
{
    public interface IBookingRepository : IDisposable
    {
        IQueryable<Booking> GetAll(int hotelId);
        Booking? Get(long id);
        IEnumerable<Booking> Find(Func<Booking, bool> predicate);
        IEnumerable<Room> GetRooms(IEnumerable<Booking> bookings);
        void Create(Booking item);
        void Delete(long id);
        void Save();
    }
}
