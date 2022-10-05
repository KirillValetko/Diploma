using AutoMapper;
using BookingWebApp.BusinessLogic.Interfaces;
using BookingWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingWebApp.Logic;

namespace BookingWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = RoleConsts.Client)]
        public IActionResult BookTheRoom(long roomId, DateTime checkInDate, DateTime checkOutdate)
        {
            _bookingService.BookTheRoom(roomId, long.Parse(User.Identity!.Name!), checkInDate, checkOutdate);

            return RedirectToAction("ViewHotels", "Hotel");
        }

        [Authorize(Roles = RoleConsts.Client)]
        public IActionResult ConfirmCancelation(long bookingId)
        {
            BookingViewModel booking = _mapper.Map<BookingViewModel>(_bookingService.Get(bookingId));

            return View(booking);
        }

        [HttpPost, ActionName("ConfirmCancelation")]
        public IActionResult CancelBooking(long bookingId)
        {
            _bookingService.CancelBooking(bookingId);

            return RedirectToAction("ViewBookings", "Booking");
        }

        [Authorize(Roles = RoleConsts.Client)]
        public IActionResult ViewBookings(int? pageIndex)
        {
            long clientId = long.Parse(User.Identity!.Name!);

            List<BookingViewModel> bookings = new(_mapper.Map<IEnumerable<BusinessLogic.Models.Booking>, List<BookingViewModel>>(_bookingService.GetBookings(clientId)));

            int pageSize = 10;

            return View(PaginatedList<BookingViewModel>.Create(bookings, pageIndex ?? 1, pageSize));
        }
    }
}
