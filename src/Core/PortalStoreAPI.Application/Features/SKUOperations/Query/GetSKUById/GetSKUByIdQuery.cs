using MediatR;
using PortalStoreAPI.Application.Dto;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Query.GetSKUById
{
    public class GetSKUByIdQuery : IRequest<ServiceResponse<SKUViewDto>>
    {
        public int Id { get; set; }
    }
}
