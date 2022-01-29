using System.Collections.Generic;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Core.Repositories
{
    public interface IBookingInfoRepository : IGenericRepository<BookingInfo>
    {
        Task<List<BookingInfo>> GetBookingInfosWithCustomersAsync();
    }
}
