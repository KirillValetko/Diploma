using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingWebApp.DataAccess.Interfaces;
using BookingWebApp.DataAccess.Entities;
using BookingWebApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApp.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDBContext dbcontext;

        public BookingRepository(BookingDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IQueryable<Booking> GetAll(int hotelId)
        {
            return dbcontext.Bookings.Where(booking => booking.Room.HotelId == hotelId);
        }

        public Booking? Get(long id)
        {
            return dbcontext.Bookings.Find(id);
        }

        public IEnumerable<Booking> Find(Func<Booking, bool> predicate)
        {
            return dbcontext.Bookings.Where(predicate).ToList();
        }

        public IEnumerable<Room> GetRooms(IEnumerable<Booking> bookings)
        {
            List<Room> rooms = new List<Room>();
            foreach (Booking booking in bookings)
                rooms.Add(dbcontext.Rooms.Find(booking.RoomId)!);
            return rooms;
        }

        public void Create(Booking item)
        {
            dbcontext.Bookings.Add(item);
        }

        public void Delete(long id)
        {
            Booking? booking = dbcontext.Bookings.Find(id);
            if (booking != null)            
                dbcontext.Bookings.Remove(booking);         
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
