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
    public class ClientRepository : IClientRepository
    {
        private readonly BookingDBContext dbcontext;

        public ClientRepository(BookingDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Client? Get(long id)
        {
            return dbcontext.Clients.Find(id);
        }

        public void Create(Client item)
        {
            dbcontext.Clients.Add(item);
            dbcontext.SaveChanges();
        }

        public void Update(Client item)
        {
            dbcontext.Entry(item).State = EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public Client? Find(Func<Client, bool> predicate)
        {
            return dbcontext.Clients.Where(predicate).FirstOrDefault();
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
