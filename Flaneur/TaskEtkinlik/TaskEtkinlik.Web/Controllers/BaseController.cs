using Microsoft.AspNetCore.Mvc;

namespace TaskEtkinlik.Web.Controllers
{
    
    public class BaseController : Controller
    {
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
        public void SetCookie(string userName)
        {

            HttpContext.Response.Cookies.Append("memberUserNameCookie", userName, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
        }
        public string GetCookie()
        {
            string cookieValue = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("memberUserNameCookie", out cookieValue);
            return cookieValue;

        }

    }
}
