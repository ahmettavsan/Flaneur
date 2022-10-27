using Microsoft.AspNetCore.Mvc;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Web.Services;

namespace TaskEtkinlik.Web.Controllers
{
    public class BasketController : BaseController
    {
        private readonly BasketTicketApiService _apiService;
        private readonly MemberApiService _memberApiService;

        public BasketController(BasketTicketApiService apiService, MemberApiService memberApiService)
        {
            _apiService = apiService;
            _memberApiService = memberApiService;
        }

        public async Task<IActionResult> AddTicket(int id)
        {  
            //------------------------------------------BURADA SIKINTI VAR TRY CATCH KULLANMA
            string userName=string.Empty;
            HttpContext.Request.Cookies.TryGetValue("memberUserNameCookie", out userName);
           
                var newBasketTicketDto = new BasketTicketDto()
                {

                    AppUserName = userName,
                    EventId = id,
                    IsDeleted = false
                };
                var result = await _apiService.Save(newBasketTicketDto);
                    
                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            return RedirectToAction("Error", "Error");






        }
        //public async Task<IActionResult> GetTicket()
        //{
        //    string userName = string.Empty;
        //    HttpContext.Request.Cookies.TryGetValue("memberUserNameCookie", out userName);
        //    var data= await _apiService.GetAll(userName);
        //    return View(data);

        //}

    }
}
