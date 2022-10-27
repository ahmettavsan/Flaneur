using Microsoft.AspNetCore.Mvc;

namespace TaskEtkinlik.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
