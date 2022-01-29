using System.Collections.Generic;

namespace DjValetingCarBookingApp.Core.DTOs
{
    public class CustomerWithBookingInfosDto : CustomerDto
    {
        public List<BookingInfoDto> BookingInfos { get; set; }
    }
}
