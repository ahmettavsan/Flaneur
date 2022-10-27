using TaskEtkinlik.Core.DTOs;

namespace TaskEtkinlik.Web.Services
{
    public class EventApiService
    {
        private readonly HttpClient _httpClient;

        public EventApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<EventWithCategoryDto>> EventWithCategory()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<EventWithCategoryDto>>>("Events/GetEventsWithCategory");
            
           var error= response.Errors;
            if (response.Data == null)
            {
                throw new Exception("Sunucuya Bağlanırken Hata Oluştu");
                throw new Exception(response.Errors.ToString());

            }

            return response.Data;
        }
        public async Task<EventDto> Save(EventDto eventDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Events",eventDto);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<EventDto>>();
            return responseBody.Data;

        }
        public async Task<bool> Update(EventDto eventDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Events", eventDto);///////////
            return response.IsSuccessStatusCode;

        }
        public async Task<EventDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<EventDto>>($"Events/{id}");
            if (response.Data!=null)
            {
                return response.Data;

            }
            return new EventDto() { Name= "The event you were looking at was not found",ImagePath="~/css/images/404.png",Capacity=0,Stock=0, };
            //if (response.Errors.Any())
            //{
            //    throw new Exception(response.Errors.ToString());
            //}
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"Events/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
