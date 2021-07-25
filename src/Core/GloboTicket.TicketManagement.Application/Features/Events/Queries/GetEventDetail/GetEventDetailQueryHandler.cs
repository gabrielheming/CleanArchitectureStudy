using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IAsyncRepository<Category> categoryRepository;

        public GetEventDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Event> eventRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            Event @event = await eventRepository.GetByIdAsync(request.Id);
            EventDetailVm eventDetailDto = mapper.Map<EventDetailVm>(@event);

            Category category = await categoryRepository.GetByIdAsync(eventDetailDto.CategoryId);

            eventDetailDto.Category = mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}