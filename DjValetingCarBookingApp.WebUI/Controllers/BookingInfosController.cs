using AutoMapper;
using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.DTOs;
using DjValetingCarBookingApp.Core.Services;
using DjValetingCarBookingApp.WebUI.Filters;
using DjValetingCarBookingApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.WebUI.Controllers
{
    public class BookingInfosController : Controller
    {
        private readonly BookingInfoApiService _bookingInfoApiService;

        public BookingInfosController(BookingInfoApiService bookingInfoApiService)
        {
            _bookingInfoApiService = bookingInfoApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bookingInfoApiService.GetBookingInfosWithCustomersAsync());
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookingInfoWithCustomerDto bookingInfoWithCustomerDto)
        {
            if (ModelState.IsValid)
            {
                await _bookingInfoApiService.SaveAsync(bookingInfoWithCustomerDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<BookingInfo>))]
        public async Task<IActionResult> Update(int id)
        {
            var customResponseDto = await _bookingInfoApiService.GetBookingInfosWithCustomersAsync();

            var bookingInfo = customResponseDto.FirstOrDefault(x => x.Id == id);

            return View(bookingInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookingInfoWithCustomerDto bookingInfoDto)
        {
            if (ModelState.IsValid)
            {
                await _bookingInfoApiService.UpdateAsync(bookingInfoDto);

                return RedirectToAction(nameof(Index));
            }

            return View(bookingInfoDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _bookingInfoApiService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
