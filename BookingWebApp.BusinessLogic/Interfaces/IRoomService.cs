using BookingWebApp.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Interfaces
{
    public interface IRoomService
    {
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
    }
}
