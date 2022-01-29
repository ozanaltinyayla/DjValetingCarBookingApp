using DjValetingCarBookingApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.WebUI.Services
{
    public class CustomerApiService
    {
        private readonly HttpClient _httpClient;

        public CustomerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CustomerDto>>>("customers");

            return response.Data;
        }
    }
}
