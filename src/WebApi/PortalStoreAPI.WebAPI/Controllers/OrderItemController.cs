using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.OrderItemOperations.Commands.CreateOrderItem;
using PortalStoreAPI.Application.Features.OrderItemOperations.Commands.DeleteOrderItem;
using PortalStoreAPI.Application.Features.OrderItemOperations.Commands.UpdateOrderItem;
using PortalStoreAPI.Application.Features.OrderItemOperations.Queries.GetAllOrderItemByOrderId;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var query = new GetAllOrderItemsByOrderIdQuery()
            {
                OrderId = orderId
            };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateOrderItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateOrderItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrderItemCommand()
            {
                Id = id
            };

            return Ok(await _mediator.Send(command));
        }
    }
}
