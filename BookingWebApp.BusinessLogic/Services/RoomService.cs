using AutoMapper;
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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public void CreateRoom(Room room)
        {
            _roomRepository.Create(_mapper.Map<DataAccess.Entities.Room>(room));
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(_mapper.Map<DataAccess.Entities.Room>(room));
        }
    }
}
