using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Repository.Repositories
{
    public class BookingInfoRepository : GenericRepository<BookingInfo>, IBookingInfoRepository
    {
        public BookingInfoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<BookingInfo>> GetBookingInfosWithCustomersAsync()
        {
            return await _context.BookingInfos.Include(x => x.Customer).ToListAsync();
        }
    }
}
