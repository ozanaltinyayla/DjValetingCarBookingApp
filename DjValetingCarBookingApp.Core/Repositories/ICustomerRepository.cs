using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Core.Repositories
{
    public interface ICustomerRepository :IGenericRepository<Customer>
    {
        Task<Customer> GetSingleCustomerByIdWithBookingInfosAsync(int customerId);
    }
}
