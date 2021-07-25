using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Events;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, EventListVm>().ReverseMap();
        }
    }
}