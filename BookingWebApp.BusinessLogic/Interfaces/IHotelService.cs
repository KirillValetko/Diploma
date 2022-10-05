using BookingWebApp.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Interfaces
{
    public interface IHotelService : IUser<Hotel>
    {
        IEnumerable<Hotel> GetHotels();
        IEnumerable<Room> GetRooms(int hotelId);
        Hotel Get(int hotelId);
    }
}
