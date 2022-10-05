using AutoMapper;
using BookingWebApp.DataAccess.Interfaces;
using BookingWebApp.BusinessLogic.Interfaces;

namespace BookingWebApp.BusinessLogic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public IEnumerable<Models.Booking> GetBookings(long clientId)
        {
            List<Models.Booking> bookings = new(_mapper.Map<IEnumerable<DataAccess.Entities.Booking>, List<Models.Booking>>(
                _bookingRepository.Find(booking => booking.ClientId == clientId && booking.IsActive)));

            Models.Room room;

            foreach (var booking in bookings)
            {
                room = _mapper.Map<Models.Room>(_roomRepository.Get(booking.RoomId));
                booking.RoomNumber = room.RoomNumber;
                booking.Hotel = _hotelRepository.GetName(room.HotelId);
            }

            return bookings;
        }

        public void BookTheRoom(long roomId, long clientId, DateTime CheckIn, DateTime CheckOut)
        {
            Models.Booking booking = new Models.Booking
            {
                ClientId = clientId,
                RoomId = roomId,
                CheckInDate = CheckIn,
                CheckOutDate = CheckOut,
                IsActive = true
            };
            _bookingRepository.Create(_mapper.Map<DataAccess.Entities.Booking>(booking));
            _bookingRepository.Save();
        }

        public void CancelBooking(long bookingId)
        {
            _bookingRepository.Delete(bookingId);
            _bookingRepository.Save();
        }

        public IEnumerable<Models.Room> FindUnbookedRooms(int hotelId, DateTime CheckIn, DateTime CheckOut)
        {
            List<DataAccess.Entities.Booking> bookings = _bookingRepository
                .GetAll(hotelId)
                .Where(booking => booking.IsActive && (booking.CheckInDate >= CheckOut || booking.CheckOutDate <= CheckIn))
                .ToList();
            List<DataAccess.Entities.Room> rooms = new (_bookingRepository.GetRooms(bookings));
            return _mapper.Map<IEnumerable<DataAccess.Entities.Room>, List<Models.Room>>(rooms);
        }

        public Models.Booking Get(long bookingId)
        {
            Models.Booking booking = _mapper.Map<Models.Booking>(_bookingRepository.Get(bookingId));

            Models.Room room = _mapper.Map<Models.Room>(_roomRepository.Get(booking.RoomId));

            booking.RoomNumber = room.RoomNumber;
            booking.Hotel = _hotelRepository.GetName(room.HotelId);

            return booking;
        }
    }
}
