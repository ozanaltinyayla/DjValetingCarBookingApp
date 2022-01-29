using DjValetingCarBookingApp.Core.Models;
using System.Collections.Generic;

namespace DjValetingCarBookingApp.Core
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public ICollection<BookingInfo> BookingInfos { get; set; }
    }
}
