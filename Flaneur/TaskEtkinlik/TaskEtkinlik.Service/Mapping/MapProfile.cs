using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventWithCategoryDto>().ReverseMap();
            CreateMap<Event, EventWithPlaceDto>().ReverseMap();
            CreateMap<Event, EventWithTicketsDto>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Member, MemberWithBasketTicketDto>().ReverseMap();
            CreateMap<BasketTicket, BasketTicketDto>().ReverseMap();
           

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithEventsDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<District, DistrictWithPlaces>().ReverseMap();
            CreateMap<Place, PlaceDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<Ticket, TicketWithEventDto>().ReverseMap();
            CreateMap<Event, GetEventAllDto>().ReverseMap();
            CreateMap<AppUser, UserAppDto>().ReverseMap();


















        }
    }
}
