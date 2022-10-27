using TaskEtkinlik.Core.DTOs;

namespace TaskEtkinlik.Web.Services
{
    public class BasketTicketApiService
    {
        private readonly HttpClient _httpClient;

        public BasketTicketApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Save(BasketTicketDto basketTicketDto)
        {
          var result=  await _httpClient.PostAsJsonAsync("BasketTicket", basketTicketDto);
            return result.IsSuccessStatusCode;
        }
        public async Task<List<BasketTicketDto>> GetAll(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<BasketTicketDto>>>($"BasketTicket/GetTicketByUserId/{id}");
            return result.Data;
        }
    }
}
