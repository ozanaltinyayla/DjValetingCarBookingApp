using DjValetingCarBookingApp.Core.DTOs;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<CustomResponseDto<CustomerWithBookingInfosDto>> GetSingleCustomerByIdWithBookingInfosAsync(int customerId);
    }
}
