using AutoMapper;
using DjValetingCarBookingApp.Core;
using DjValetingCarBookingApp.Core.DTOs;
using DjValetingCarBookingApp.Core.Repositories;
using DjValetingCarBookingApp.Core.Services;
using DjValetingCarBookingApp.Core.UnitOfWorks;
using System;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerWithBookingInfosDto>> GetSingleCustomerByIdWithBookingInfosAsync(int customerId)
        {
            var customer = await _customerRepository.GetSingleCustomerByIdWithBookingInfosAsync(customerId);

            var customerDto = _mapper.Map<CustomerWithBookingInfosDto>(customer);

            return CustomResponseDto<CustomerWithBookingInfosDto>.Success(200, customerDto);
        }
    }
}
