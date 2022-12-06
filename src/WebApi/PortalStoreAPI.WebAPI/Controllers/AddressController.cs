using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.AddressOperaions.Commands.CreateAddress;
using PortalStoreAPI.Application.Features.AddressOperaions.Commands.DeleteAddress;
using PortalStoreAPI.Application.Features.AddressOperaions.Commands.UpdateAddress;
using PortalStoreAPI.Application.Features.AddressOperaions.Queries.GetAllAdressesByCustomerId;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            var query = new GetAllAddressByCustomerIdQuery()
            {
                CustomerId = customerId
            };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAddressCommand()
            {
                Id = id
            };

            return Ok(await _mediator.Send(command));
        }
    }
}
