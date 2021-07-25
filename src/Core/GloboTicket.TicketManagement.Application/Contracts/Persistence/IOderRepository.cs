using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts
{
    public interface IOderRepository : IAsyncRepository<Order>
    {

    }
}