using System;
using System.Collections.Generic;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid EventId { get; set; }
    }
}