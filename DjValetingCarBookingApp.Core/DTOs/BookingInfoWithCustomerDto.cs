namespace DjValetingCarBookingApp.Core.DTOs
{
    public class BookingInfoWithCustomerDto : BookingInfoDto
    {
        public CustomerDto Customer { get; set; }
    }
}
