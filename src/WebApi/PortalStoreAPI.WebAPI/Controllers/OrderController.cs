using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.OrderOperations.Commands.CreateOrder;
using PortalStoreAPI.Application.Features.OrderOperations.Commands.UpdateOrder;
using PortalStoreAPI.Application.Features.OrderOperations.Queries.GetAllOrdersByCustomerId;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            var query = new GetAllOrdersByCustomerIdQuery()
            {
                CustomerId = customerId
            };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
