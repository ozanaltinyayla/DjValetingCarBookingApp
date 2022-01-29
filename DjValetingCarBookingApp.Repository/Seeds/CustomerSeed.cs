using DjValetingCarBookingApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DjValetingCarBookingApp.Repository.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, Name = "Linus Torvalds", ContactNumber = "5559998877", Email = "linustorvalds@gmail.com" },
                    new Customer { Id = 2, Name = "Ada Lovelace", ContactNumber = "3337775544", Email = "adalovelace@gmail.com" },
                    new Customer { Id = 3, Name = "Alan Turing", ContactNumber = "6668889955", Email = "alanturing@gmail.com" },
                    new Customer { Id = 4, Name = "Ken Thompson", ContactNumber = "7779005544", Email = "kenthompson@gmail.com" },
                    new Customer { Id = 5, Name = "Dennis Ritchie", ContactNumber = "1116667799", Email = "dennisritchie@gmail.com" });
        }
    }
}
