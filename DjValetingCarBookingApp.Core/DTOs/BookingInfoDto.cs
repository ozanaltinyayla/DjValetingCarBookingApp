using System;

namespace DjValetingCarBookingApp.Core.DTOs
{
    public class BookingInfoDto : BaseDto
    {
        public DateTime BookingDate { get; set; }
        public int Flexibility { get; set; }
        public VehicleSize VehicleSize { get; set; }
        public int CustomerId { get; set; }
    }

    public enum VehicleSize
    {
        Small = 1,
        Medium = 2,
        Large = 3,
        Van = 4
    }
}
