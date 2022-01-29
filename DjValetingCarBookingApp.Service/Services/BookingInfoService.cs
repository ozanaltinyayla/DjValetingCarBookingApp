using AutoMapper;
using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.DTOs;
using DjValetingCarBookingApp.Core.Repositories;
using DjValetingCarBookingApp.Core.Services;
using DjValetingCarBookingApp.Core.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Service.Services
{
    public class BookingInfoService : Service<BookingInfo>, IBookingInfoService
    {
        private readonly IBookingInfoRepository _bookingInfoRepository;
        private readonly IMapper _mapper;

        public BookingInfoService(IGenericRepository<BookingInfo> repository, IUnitOfWork unitOfWork, IMapper mapper, IBookingInfoRepository bookingInfoRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _bookingInfoRepository = bookingInfoRepository;
        }

        public async Task<CustomResponseDto<List<BookingInfoWithCustomerDto>>> GetBookingInfosWithCustomersAsync()
        {
            var bookingInfos = await _bookingInfoRepository.GetBookingInfosWithCustomersAsync();

            var bookingInfosDto = _mapper.Map<List<BookingInfoWithCustomerDto>>(bookingInfos);

            return CustomResponseDto<List<BookingInfoWithCustomerDto>>.Success(200, bookingInfosDto);
        }
    }
}
