using BookingWebApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Interfaces
{
    public interface IRoomRepository : IDisposable
    {
        IEnumerable<Room> GetAll(int hotelId);
        Room? Get(long id);
        IEnumerable<Room> Find(Func<Room, bool> predicate);
        void Create(Room item);
        void Update(Room item);
        void Delete(long id);
        void Save();
    }
}
