using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreAPI.Application.Features.CategoryOperations.Commands.CreateCategory;
using PortalStoreAPI.Application.Features.CategoryOperations.Commands.DeleteCategory;
using PortalStoreAPI.Application.Features.CategoryOperations.Commands.UpdateCategory;
using PortalStoreAPI.Application.Features.CategoryOperations.Queries.GetAllCategories;

namespace PortalStoreAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCategoriesQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand()
            {
                Id = id
            };

            return Ok(await _mediator.Send(command));
        }

    }
}
