using AutoMapper;
using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.DTOs;

namespace DjValetingCarBookingApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<BookingInfo, BookingInfoDto>().ReverseMap();
            CreateMap<BookingInfo, BookingInfoWithCustomerDto>();
            CreateMap<Customer, CustomerWithBookingInfosDto>();
        }
    }
}
