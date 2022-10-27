using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Services;

namespace TaskEtkinlik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventservice;
        private readonly IService<Event> _service;

        public EventsController(IService<Event> service, IMapper mapper, IEventService eventservice)
        {
            _service = service;
            _mapper = mapper;
            _eventservice = eventservice;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProp()
        {
           
            return CreateActionResult(await _eventservice.GetEventAllProp());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEventsWithCategory()
        {
            
            return CreateActionResult(await _eventservice.GetEventsWithCategory());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEventsWithPlace()
        {
            return CreateActionResult(await _eventservice.GetEventsWithPlace());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEventsWithTicket()
        {
            return CreateActionResult(await _eventservice.GetEventsWithTicket());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events=await _service.GetAllAsync();
            var eventsdto=_mapper.Map<List<EventDto>>(events.ToList());
            //return Ok(CustomResponseDto<List<EventDto>>.Succes(200, eventsdto));
            return CreateActionResult(CustomResponseDto<List<EventDto>>.Succes(200,eventsdto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var etkinlik = await _service.GetByIdAsync(id);
            var etkinlikdto = _mapper.Map<EventDto>(etkinlik);
            return CreateActionResult<EventDto>(CustomResponseDto<EventDto>.Succes(200, etkinlikdto));

        }
        [HttpPost]
        public async Task<IActionResult> Save(EventDto neweventDto)
        {   
            var etkinlikekli=await _service.AddAsync(_mapper.Map<Event>(neweventDto));
            var etkinlikdto=_mapper.Map<EventDto>(etkinlikekli);
            return CreateActionResult<EventDto>(CustomResponseDto<EventDto>.Succes(201, etkinlikdto));

        }
        [HttpPut]
        public async Task<IActionResult> Update(EventDto eventDto)
        {
            await _service.UpdateAsync(_mapper.Map<Event>(eventDto));
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var etkinlik=await _service.GetByIdAsync(id);
            //if (etkinlik==null)
            //{
            //    return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Fail(404,"BU ID'E SAHİP ETKİNLİK BULUNAMADI"));
            //}
            //eğer etkinlik yoksa metot patlıycak
            //buyüzden kontrol etmemiz lazım var mı yokmu diye
            await _service.RemoveAsync(etkinlik);
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
    }

}
