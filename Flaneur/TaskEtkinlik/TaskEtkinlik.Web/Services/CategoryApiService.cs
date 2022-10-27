using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TaskEtkinlik.Core.DTOs;

namespace TaskEtkinlik.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
          var response=  await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("Categories");
            return response.Data;
        }

        public async Task<List<CategoryWithEventsDto>> GetCategoryWithEvents(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryWithEventsDto>>>($"Categories/GetCategoryWithEvents/{id}");
            if (response.Data==null)
            {
                throw new Exception("Sunucuya Bağlanırken Hata Oluştu");
                throw new Exception(response.Errors.ToString());

            }
            return response.Data;
        }
        public async Task<bool> Update(CategoryDto categoryDto)
        {
            
            return (await _httpClient.PutAsJsonAsync("Categories", categoryDto)).IsSuccessStatusCode;
        }
    }
}
