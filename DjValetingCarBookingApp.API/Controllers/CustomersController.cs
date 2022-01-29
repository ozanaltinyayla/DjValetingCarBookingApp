using AutoMapper;
using DjValetingCarBookingApp.Core.DTOs;
using DjValetingCarBookingApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _service = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDto));
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleCustomerByIdWithBookingInfos(int customerId)
        {
            return CreateActionResult(await _service.GetSingleCustomerByIdWithBookingInfosAsync(customerId));
        }
    }
}
