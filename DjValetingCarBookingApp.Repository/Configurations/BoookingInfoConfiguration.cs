using DjValetingCarBookingApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DjValetingCarBookingApp.Repository.Configurations
{
    public class BoookingInfoConfiguration : IEntityTypeConfiguration<BookingInfo>
    {
        public void Configure(EntityTypeBuilder<BookingInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BookingDate).IsRequired();
            builder.Property(x => x.Flexibility).IsRequired();
            builder.Property(x => x.VehicleSize).IsRequired();

            builder.ToTable("BookingInfos");

            builder.HasOne(x => x.Customer).WithMany(x => x.BookingInfos).HasForeignKey(x => x.CustomerId);
        }
    }
}
