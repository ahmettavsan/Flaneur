using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskEtkinlik.Web.Models;
using TaskEtkinlik.Web.Services;

namespace TaskEtkinlik.Web.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventApiService _eventApiService;

        public HomeController(ILogger<HomeController> logger, EventApiService eventApiService)
        {
            _logger = logger;
            _eventApiService = eventApiService;
        }

        public async Task<IActionResult> Index()
        {

           
            var data = await _eventApiService.EventWithCategory();


            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}