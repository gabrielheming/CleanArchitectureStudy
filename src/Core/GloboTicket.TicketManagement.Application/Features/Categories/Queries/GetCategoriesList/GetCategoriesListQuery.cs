using System.Collections.Generic;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryListVm>>
    {

    }
}