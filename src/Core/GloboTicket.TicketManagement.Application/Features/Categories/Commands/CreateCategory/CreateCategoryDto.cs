using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}