using MediatR;
using MernisService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.CustomerOperations.Commands.CreateCustomer;
using PortalStoreAPI.Application.Features.CustomerOperations.Commands.DeleteCustomer;
using PortalStoreAPI.Application.Features.CustomerOperations.Commands.UpdateCustomer;
using PortalStoreAPI.Application.Features.CustomerOperations.Queries.GetAllCustomers;
using PortalStoreAPI.Application.Features.CustomerOperations.Queries.GetCustomerById;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomerQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCustomerByIdQuery()
            {
                Id = id
            };

            return Ok(await _mediator.Send(query));
        }


        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            //Mernis Service Verification
            var client = new MernisService.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(command.TCID), command.Firstname, command.LastName, command.BirthDate.Year);
            var result = response.Body.TCKimlikNoDogrulaResult;

            if(!result)
            {
                return BadRequest("Please check your ID informations");
            }

            return Ok(await _mediator.Send(command));

        }

       [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand()
            {
                Id = id
            };

            return Ok(await _mediator.Send(command));
        }
    }
}
