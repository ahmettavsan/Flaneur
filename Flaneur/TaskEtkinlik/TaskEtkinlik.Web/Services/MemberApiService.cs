using Microsoft.AspNetCore.CookiePolicy;
using TaskEtkinlik.Core.DTOs;

namespace TaskEtkinlik.Web.Services
{
    public class MemberApiService
    {
        private readonly HttpClient _httpClient;

        public MemberApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Save(CreateUserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Members/Save", userDto);
            if (!response.IsSuccessStatusCode)
            {
               return false;
            }
            return response.IsSuccessStatusCode;
            

        }
        public async Task<AppUserDto> Login(LoginDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("Members/Login", user);
            var responseBody= await response.Content.ReadFromJsonAsync<CustomResponseDto<AppUserDto>>();
            //if (responseBody.Data==null)
            //{
            //    return responseBody.Errors;
            //}
            return responseBody.Data;
        }

        //public async Task<AppUserDto> FindName(string name)
        //{
        //    var response = await _httpClient.GetFromJsonAsync("members/");
        //}

    }
}
