using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<ServiceResponse<string>>
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
