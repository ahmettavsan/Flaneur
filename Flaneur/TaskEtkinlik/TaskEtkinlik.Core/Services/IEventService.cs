using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.Services
{
    public interface IEventService:IService<Event>
    {
        Task<CustomResponseDto<List<EventWithCategoryDto>>> GetEventsWithCategory();
        Task<CustomResponseDto<List<EventWithPlaceDto>>> GetEventsWithPlace();
        Task<CustomResponseDto<List<EventWithTicketsDto>>> GetEventsWithTicket();
        Task<CustomResponseDto<List<GetEventAllDto>>> GetEventAllProp();

    }
}
