using BookingWebApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Interfaces
{
    public interface IHotelRepository : IDisposable
    {
        IEnumerable<Hotel> GetAll();
        Hotel? Get(int id);
        string GetName(int id);
        Hotel? Find(Func<Hotel, bool> predicate);
        void Create(Hotel item);
        void Update(Hotel item);
        void Delete(int id);
        void Save();
    }
}
