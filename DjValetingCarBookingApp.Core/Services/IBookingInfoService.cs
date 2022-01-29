using DjValetingCarBookingApp.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Core.Services
{
    public interface IBookingInfoService : IService<BookingInfo>
    {
        Task<CustomResponseDto<List<BookingInfoWithCustomerDto>>> GetBookingInfosWithCustomersAsync();
    }
}
