using AutoMapper;
using BookingWebApp.BusinessLogic.Interfaces;
using BookingWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookingWebApp.Logic;

namespace BookingWebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_clientService.IsEmailUnique(clientViewModel.EMail!))
                {
                    return View("Error");
                }

                _clientService.CreateUser(_mapper.Map<BusinessLogic.Models.Client>(clientViewModel));

                clientViewModel = _mapper.Map<ClientViewModel>(_clientService.AuthenticateUser(clientViewModel.EMail!, clientViewModel.PasswordHash!));

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, RoleConsts.Client),
                    new Claim(ClaimTypes.Name, clientViewModel.ClientId!.Value.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties{};

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("ViewHotels", "Hotel");
            }
            return View(clientViewModel);
        }
    }
}