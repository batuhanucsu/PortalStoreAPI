using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.DeleteSKU
{
    public class DeleteSKUCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
    }
}
