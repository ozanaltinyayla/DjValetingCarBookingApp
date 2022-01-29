using DjValetingCarBookingApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DjValetingCarBookingApp.Repository.Seeds
{
    public class BookingInfoSeed : IEntityTypeConfiguration<BookingInfo>
    {
        public void Configure(EntityTypeBuilder<BookingInfo> builder)
        {
            builder.HasData(
                    new BookingInfo { Id = 1, CustomerId = 1, BookingDate = DateTime.Now, Flexibility = 1, VehicleSize = VehicleSize.Large },
                    new BookingInfo { Id = 2, CustomerId = 1, BookingDate = DateTime.Now.AddDays(1), Flexibility = 2, VehicleSize = VehicleSize.Medium },
                    new BookingInfo { Id = 3, CustomerId = 1, BookingDate = DateTime.Now.AddDays(3), Flexibility = 3, VehicleSize = VehicleSize.Small },
                    new BookingInfo { Id = 4, CustomerId = 2, BookingDate = DateTime.Now.AddDays(4), Flexibility = 1, VehicleSize = VehicleSize.Medium },
                    new BookingInfo { Id = 5, CustomerId = 2, BookingDate = DateTime.Now.AddDays(5), Flexibility = 2, VehicleSize = VehicleSize.Small },
                    new BookingInfo { Id = 6, CustomerId = 2, BookingDate = DateTime.Now.AddDays(6), Flexibility = 3, VehicleSize = VehicleSize.Large },
                    new BookingInfo { Id = 7, CustomerId = 3, BookingDate = DateTime.Now.AddDays(3), Flexibility = 1, VehicleSize = VehicleSize.Van },
                    new BookingInfo { Id = 8, CustomerId = 3, BookingDate = DateTime.Now.AddDays(7), Flexibility = 2, VehicleSize = VehicleSize.Large },
                    new BookingInfo { Id = 9, CustomerId = 3, BookingDate = DateTime.Now.AddDays(14), Flexibility = 3, VehicleSize = VehicleSize.Medium },
                    new BookingInfo { Id = 10, CustomerId = 4, BookingDate = DateTime.Now.AddDays(11), Flexibility = 1, VehicleSize = VehicleSize.Van },
                    new BookingInfo { Id = 11, CustomerId = 4, BookingDate = DateTime.Now.AddDays(12), Flexibility = 2, VehicleSize = VehicleSize.Small },
                    new BookingInfo { Id = 12, CustomerId = 4, BookingDate = DateTime.Now.AddDays(15), Flexibility = 3, VehicleSize = VehicleSize.Large },
                    new BookingInfo { Id = 13, CustomerId = 5, BookingDate = DateTime.Now.AddDays(21), Flexibility = 1, VehicleSize = VehicleSize.Small },
                    new BookingInfo { Id = 14, CustomerId = 5, BookingDate = DateTime.Now.AddDays(24), Flexibility = 2, VehicleSize = VehicleSize.Medium },
                    new BookingInfo { Id = 15, CustomerId = 5, BookingDate = DateTime.Now.AddDays(25), Flexibility = 3, VehicleSize = VehicleSize.Large });
        }
    }
}
