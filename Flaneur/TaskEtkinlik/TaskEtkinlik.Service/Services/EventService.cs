using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Repositories;
using TaskEtkinlik.Core.Services;
using TaskEtkinlik.Core.UnitOfWork;

namespace TaskEtkinlik.Service.Services
{
    public class EventService : Service<Event>, IEventService
    {
        private readonly IEventRepository _eventrepository;
        private readonly IMapper _mapper;
        public EventService(IUnitOfWork unitOfWork, IGenericRepository<Event> repository, IEventRepository eventrepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventrepository = eventrepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<GetEventAllDto>>> GetEventAllProp()
        {
            var events = await _eventrepository.GetEventAll();
            var eventsdto=_mapper.Map<List<GetEventAllDto>>(events);
            return CustomResponseDto<List<GetEventAllDto>>.Succes(200, eventsdto);
        }

        public async Task<CustomResponseDto<List<EventWithCategoryDto>>> GetEventsWithCategory()
        {
            var events = await _eventrepository.GetEventsWithCategory();
            var eventsdto=_mapper.Map<List<EventWithCategoryDto>>(events);
            return CustomResponseDto<List<EventWithCategoryDto>>.Succes(200, eventsdto);
        }

        public async Task<CustomResponseDto<List<EventWithPlaceDto>>> GetEventsWithPlace()
        {
            var events = await _eventrepository.GetEventsWithPlace();
            var eventsdto=_mapper.Map<List<EventWithPlaceDto>>(events);
            return CustomResponseDto<List<EventWithPlaceDto>>.Succes(200, eventsdto);
        }

        public async Task<CustomResponseDto<List<EventWithTicketsDto>>> GetEventsWithTicket()
        {
            var events=await _eventrepository.GetEventsWithTicket();
            var eventsdto=_mapper.Map<List<EventWithTicketsDto>>(events);
            return CustomResponseDto<List<EventWithTicketsDto>>.Succes(200, eventsdto);
        }
    }
}
