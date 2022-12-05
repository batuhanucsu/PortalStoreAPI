using MediatR;
using PortalStoreAPI.Application.Dto;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Query.GetAllSKUs
{
    public class GetAllSKUsQuery : IRequest<ServiceResponse<List<SKUViewDto>>>
    {
    }
}
