using AutoMapper;

namespace BookingWebApp.Logic
{
    public class Mapper : Profile
    {
        //private readonly IMapper _mapClient;
        //
        public Mapper()
        {
            CreateMap<DataAccess.Entities.Booking, BusinessLogic.Models.Booking>().ReverseMap();
            CreateMap<BusinessLogic.Models.Booking, Models.BookingViewModel>().ReverseMap();

            CreateMap<DataAccess.Entities.Client, BusinessLogic.Models.Client>().ReverseMap();
            CreateMap<BusinessLogic.Models.Client, Models.ClientViewModel>().ReverseMap();

            CreateMap<DataAccess.Entities.Hotel, BusinessLogic.Models.Hotel>().ReverseMap();
            CreateMap<BusinessLogic.Models.Hotel, Models.HotelViewModel>().ReverseMap();

            CreateMap<DataAccess.Entities.Room, BusinessLogic.Models.Room>().ReverseMap();
            CreateMap<BusinessLogic.Models.Room, Models.RoomViewModel>().ReverseMap();
        }
    }
}
