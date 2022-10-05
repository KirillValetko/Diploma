using AutoMapper;
using BookingWebApp.BusinessLogic.BusinessLogicClasses;
using BookingWebApp.BusinessLogic.Interfaces;
using BookingWebApp.BusinessLogic.Models;
using BookingWebApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.BusinessLogic.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public void CreateUser(Hotel user)
        {
            user.PasswordHash = HashProvider.GetHash(user.PasswordHash!);
            _hotelRepository.Create(_mapper.Map<DataAccess.Entities.Hotel>(user));
            _hotelRepository.Save();
        }

        public void UpdateUser(Hotel user)
        {
            _hotelRepository.Update(_mapper.Map<DataAccess.Entities.Hotel>(user));
            _hotelRepository.Save();
        }

        public Hotel? AuthenticateUser(string email, string password)
        {
            DataAccess.Entities.Hotel? hotelEntity = _hotelRepository.Find(hotel => hotel.EMail == email);
            if (hotelEntity == null)
                return null;
            if (hotelEntity.PasswordHash == HashProvider.GetHash(password))
                return _mapper.Map<Hotel>(hotelEntity);
            else
                return null;
        }

        public void ChangePassword(Hotel user, string newPassword)
        {
            user.PasswordHash = HashProvider.GetHash(newPassword);
            _hotelRepository.Update(_mapper.Map<DataAccess.Entities.Hotel>(user));
            _hotelRepository.Save();
        }

        public IEnumerable<Hotel> GetHotels()
        {
            List<DataAccess.Entities.Hotel> hotels = new List<DataAccess.Entities.Hotel>(_hotelRepository.GetAll());
            return _mapper.Map<IEnumerable<DataAccess.Entities.Hotel>, List<Hotel>>(hotels);
        }

        public IEnumerable<Room> GetRooms(int hotelId)
        {
            List<DataAccess.Entities.Room> roomEntities = _roomRepository.GetAll(hotelId).ToList();
            return _mapper.Map<IEnumerable<DataAccess.Entities.Room>, List<Room>>(roomEntities);
        }

        public Hotel Get(int hotelId)
        {
            return _mapper.Map<Hotel>(_hotelRepository.Get(hotelId));
        }

        public bool IsEmailUnique(string email)
        {
            return _hotelRepository.Find(hotel => hotel.EMail == email) == null;
        }
    }
}
