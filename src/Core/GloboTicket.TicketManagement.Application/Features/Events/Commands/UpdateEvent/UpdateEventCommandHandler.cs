using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventToUpdate = await eventRepository.GetByIdAsync(request.EventId);

            mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await eventRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}