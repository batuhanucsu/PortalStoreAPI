using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
    }
}
