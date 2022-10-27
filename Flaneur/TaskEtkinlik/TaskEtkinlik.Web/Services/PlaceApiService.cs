using TaskEtkinlik.Core.DTOs;

namespace TaskEtkinlik.Web.Services
{
    public class PlaceApiService
    {
        private readonly HttpClient _httpClient;

        public PlaceApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PlaceDto>> GetAll()
        {
           var response= await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PlaceDto>>>("Places");
            return response.Data;
        }
    }
}
