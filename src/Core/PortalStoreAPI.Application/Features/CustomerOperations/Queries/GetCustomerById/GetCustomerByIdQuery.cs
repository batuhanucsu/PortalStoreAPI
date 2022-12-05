using MediatR;
using PortalStoreAPI.Application.Dto;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<ServiceResponse<CustomerViewDto>>
    {
        public int Id { get; set; }
    }
}
