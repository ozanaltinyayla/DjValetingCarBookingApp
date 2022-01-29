using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetSingleCustomerByIdWithBookingInfosAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.BookingInfos).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }
    }
}
