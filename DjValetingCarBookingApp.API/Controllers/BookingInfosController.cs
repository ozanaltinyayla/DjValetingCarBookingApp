using AutoMapper;
using DjValetingCarBookingApp.API.Filters;
using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.DTOs;
using DjValetingCarBookingApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.API.Controllers
{
    public class BookingInfosController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IBookingInfoService _service;

        public BookingInfosController(IMapper mapper, IBookingInfoService bookingInfosService)
        {
            _mapper = mapper;
            _service = bookingInfosService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookingInfosWithCustomer()
        {
            return CreateActionResult(await _service.GetBookingInfosWithCustomersAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookingInfos = await _service.GetAllAsync();

            var bookingInfosDto = _mapper.Map<List<BookingInfoDto>>(bookingInfos);

            return CreateActionResult(CustomResponseDto<List<BookingInfoDto>>.Success(200, bookingInfosDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<BookingInfo>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookingInfo = await _service.GetByIdAsync(id);

            var bookingInfosDto = _mapper.Map<BookingInfoDto>(bookingInfo);

            return CreateActionResult(CustomResponseDto<BookingInfoDto>.Success(200, bookingInfosDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookingInfoDto bookingInfoDto)
        {
            var bookingInfo = await _service.AddAsync(_mapper.Map<BookingInfo>(bookingInfoDto));

            var bookingInfosDto = _mapper.Map<BookingInfoDto>(bookingInfo);

            return CreateActionResult(CustomResponseDto<BookingInfoDto>.Success(201, bookingInfosDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookingInfoDto bookingInfoDto)
        {
            await _service.UpdateAsync(_mapper.Map<BookingInfo>(bookingInfoDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var bookingInfo = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(bookingInfo);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
    }
}
