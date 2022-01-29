using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
