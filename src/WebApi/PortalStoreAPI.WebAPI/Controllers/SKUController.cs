using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.SKUOperations.Command.CreateSKU;
using PortalStoreAPI.Application.Features.SKUOperations.Query.GetAllSKUs;
using PortalStoreAPI.Application.Features.SKUOperations.Query.GetSKUById;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SKUController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SKUController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSKUsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetSKUByIdQuery()
            {
                Id = id
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateSKUCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
