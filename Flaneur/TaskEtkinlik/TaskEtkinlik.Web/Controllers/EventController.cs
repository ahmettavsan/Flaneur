using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Web.Services;

namespace TaskEtkinlik.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly EventApiService _eventApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly PlaceApiService _placeApiService;

        public EventController(EventApiService eventApiService, CategoryApiService categoryApiService, PlaceApiService placeApiService)
        {
            _eventApiService = eventApiService;
            _categoryApiService = categoryApiService;
            _placeApiService = placeApiService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _eventApiService.GetByIdAsync(id);
            if (result.Id==0)
            {
                return RedirectToAction("Error", "Error");
            }


            return View(result);
        }
        public async Task<IActionResult> Save()
        {
            var categoriesdto = await _categoryApiService.GetAll();
            ViewBag.categories = new SelectList(categoriesdto, "Id", "Name");
            var placesdto = await _placeApiService.GetAll();
            ViewBag.places=new SelectList(placesdto, "Id", "Name");
            return View(new EventDto());
        }
        [HttpPost]
        public async Task<IActionResult> Save(EventDto eventDto)
        {
            if (ModelState.IsValid)
            {
              var response=   await _eventApiService.Save(eventDto);
                return RedirectToAction("Detail", "Event", response.Id);
            }
            var categoriesdto = await _categoryApiService.GetAll();
            ViewBag.categories = new SelectList(categoriesdto, "Id", "Name");
            var placesdto = await _placeApiService.GetAll();
            ViewBag.places = new SelectList(placesdto, "Id", "Name");
            return View(eventDto);
        }
        public async Task<IActionResult> Update(int id)
        {
           var events=await _eventApiService.GetByIdAsync(id);
            var result = await _eventApiService.Update(events);
            return RedirectToAction("Detail", "Event", events.Id);
        }
    }
}
