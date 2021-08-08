using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TickectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
