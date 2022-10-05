using Microsoft.AspNetCore.Mvc;
using BookingWebApp.Models;
using BookingWebApp.Logic;
using BookingWebApp.BusinessLogic.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BookingWebApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModel hotelViewM)
        {
            if(ModelState.IsValid)
            {
                if(_hotelService.IsEmailUnique(hotelViewM.EMail!))
                {
                    hotelViewM.Addr = hotelViewM.Country + ", " + hotelViewM.Sity + ", " + hotelViewM.Street + ", " + hotelViewM.Building;

                    _hotelService.CreateUser(_mapper.Map<BusinessLogic.Models.Hotel>(hotelViewM));

                    hotelViewM = _mapper.Map<HotelViewModel>(_hotelService.AuthenticateUser(hotelViewM.EMail!, hotelViewM.PasswordHash!));

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, RoleConsts.Admin),
                        new Claim(ClaimTypes.Name, hotelViewM.HotelId!.Value.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("HotelRooms", "Hotel");
                }

                return View();
            }

            return View(hotelViewM);
        }

        [Authorize(Roles = RoleConsts.Admin)]
        public ActionResult HotelRooms()
        {

            return View();
        }

        public ActionResult ViewHotels(string? searchHotelByName, int? pageIndex)
        {
            List<HotelViewModel> hotels = new(_mapper.Map<IEnumerable<BusinessLogic.Models.Hotel>, List<HotelViewModel>>(_hotelService.GetHotels()));

            if (!string.IsNullOrEmpty(searchHotelByName))
                hotels = hotels.Where(hotel => hotel.HotelName!.Contains(searchHotelByName)).ToList();

            int pageSize = 10;

            return View(PaginatedList<HotelViewModel>.Create(hotels, pageIndex ?? 1, pageSize));
        }

        public ActionResult ViewInfo(int hotelId)
        {
            HotelViewModel hotel = _mapper.Map<HotelViewModel>(_hotelService.Get(hotelId));
            return View(hotel);
        }

        public ActionResult FindRoom(int hotelId)
        {


            return View();
        }


    }
}
