using BookingWebApp.DataAccess.Data;
using BookingWebApp.DataAccess.Interfaces;
using BookingWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDBContext dbcontext;

        public RoomRepository(BookingDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IEnumerable<Room> GetAll(int hotelId)
        {
            return dbcontext.Rooms.Where(room => room.HotelId == hotelId).ToList();
        }

        public Room? Get(long id)
        {
            return dbcontext.Rooms.Find(id);
        }

        public IEnumerable<Room> Find(Func<Room, bool> predicate)
        {
            return dbcontext.Rooms.Where(predicate).ToList();
        }

        public void Create(Room item)
        {
            dbcontext.Rooms.Add(item);
        }

        public void Update(Room item)
        {
            dbcontext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            Room room = dbcontext.Rooms.Find(id);
            if (room != null)
                dbcontext.Rooms.Remove(room);
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
