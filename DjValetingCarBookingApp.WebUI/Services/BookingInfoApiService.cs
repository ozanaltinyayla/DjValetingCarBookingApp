using DjValetingCarBookingApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DjValetingCarBookingApp.WebUI.Services
{
    public class BookingInfoApiService
    {
        private readonly HttpClient _httpClient;

        public BookingInfoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookingInfoWithCustomerDto>> GetBookingInfosWithCustomersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<BookingInfoWithCustomerDto>>>("bookinginfos/getbookinginfoswithcustomer");

            return response.Data;
        }

        public async Task<BookingInfoDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<BookingInfoDto>>($"bookinginfos/{id}");

            return response.Data;
        }

        public async Task<BookingInfoWithCustomerDto> SaveAsync(BookingInfoWithCustomerDto bookingInfoDto)
        {
            var response = await _httpClient.PostAsJsonAsync("bookinginfos", bookingInfoDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<BookingInfoWithCustomerDto>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(BookingInfoWithCustomerDto bookingInfoDto)
        {
            var response = await _httpClient.PutAsJsonAsync("bookinginfos", bookingInfoDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"bookinginfos/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
