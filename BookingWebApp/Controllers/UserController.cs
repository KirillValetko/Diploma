using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using BookingWebApp.Models;
using BookingWebApp.BusinessLogic.Interfaces;
using AutoMapper;

namespace BookingWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public UserController(IHotelService hotelService, IClientService clientService, IMapper mapper)
        {
            _hotelService = hotelService;
            _clientService = clientService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistrationChoice()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var user = AuthenticateUser(loginViewModel.EMail!, loginViewModel.Password!);

            if (user == null)
            {
                return View("Error");
            }

            string Role;
            if (user is HotelViewModel)
            {
                user = (HotelViewModel)user;
                Role = Logic.RoleConsts.Admin;
            }
            else
            {
                user = (ClientViewModel)user;
                Role = Logic.RoleConsts.Client;
            }

            var userId = user is HotelViewModel ? (user as HotelViewModel)!.HotelId!.Value.ToString() : (user as ClientViewModel)!.ClientId!.Value.ToString();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, Role),
                new(ClaimTypes.Name, userId)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties{};

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            if (user is HotelViewModel)
                return RedirectToAction("Index", "Hotel");
            else
                return RedirectToAction("Index", "Client");
        }

        private object? AuthenticateUser(string email, string password)
        {
            BusinessLogic.Models.Hotel? hotelModel = _hotelService.AuthenticateUser(email, password);
            if (_hotelService.AuthenticateUser(email, password) != null)
                return _mapper.Map<HotelViewModel>(hotelModel);
            else
            {
                BusinessLogic.Models.Client? clientModel = _clientService.AuthenticateUser(email, password);
                if (clientModel != null)
                    return _mapper.Map<ClientViewModel>(clientModel);
                else
                    return null;
            }
        }

        [HttpPost]
        public async void Logout() 
        {
            await HttpContext.SignOutAsync();
        }

        [Authorize]
        public IActionResult LogoutWrap()
        {
            Logout();
            return RedirectToAction("Index", "Client");
        }
    }
}
