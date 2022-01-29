using DjValetingCarBookingApp.Core.DTOs;
using FluentValidation;

namespace DjValetingCarBookingApp.Service.Validations
{
    public class BookingInfoDtoValidator : AbstractValidator<BookingInfoDto>
    {
        public BookingInfoDtoValidator()
        {
            RuleFor(x => x.Flexibility).InclusiveBetween(1, 3).WithMessage("{PropertyName} must between 1 - 3");
            RuleFor(x => x.VehicleSize).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CustomerId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
