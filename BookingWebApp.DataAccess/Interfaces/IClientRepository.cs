using BookingWebApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Interfaces
{
    public interface IClientRepository : IDisposable
    {
        Client? Get(long id);
        void Create(Client item);
        void Update(Client item);
        Client? Find(Func<Client, bool> predicate);
        void Save();
    }
}
