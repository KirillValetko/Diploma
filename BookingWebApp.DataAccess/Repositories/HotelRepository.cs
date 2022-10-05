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
    public class HotelRepository : IHotelRepository
    {
        private readonly BookingDBContext dbcontext;

        public HotelRepository(BookingDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return dbcontext.Hotels;
        }

        public string GetName(int id)
        {
            return dbcontext.Hotels.Find(id)!.HotelName;
        }

        public Hotel? Get(int id)
        {
            return dbcontext.Hotels.Find(id);
        }

        public Hotel? Find(Func<Hotel, bool> predicate)
        {
            return dbcontext.Hotels.Where(predicate).FirstOrDefault();
        }

        public void Create(Hotel item)
        {
            dbcontext.Hotels.Add(item);
            dbcontext.SaveChanges();
        }

        public void Update(Hotel item)
        {
            dbcontext.Entry(item).State = EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            Hotel hotel = dbcontext.Hotels.Find(id);
            if (hotel != null)
            {
                dbcontext.Hotels.Remove(hotel);
                dbcontext.SaveChanges();
            }
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
