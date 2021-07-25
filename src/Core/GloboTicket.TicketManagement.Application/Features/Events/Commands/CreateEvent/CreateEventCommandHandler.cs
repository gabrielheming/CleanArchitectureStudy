using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = mapper.Map<Event>(request);

            @event = await eventRepository.AddAsync(@event);

            return @event.EventId;
        }
    }
}