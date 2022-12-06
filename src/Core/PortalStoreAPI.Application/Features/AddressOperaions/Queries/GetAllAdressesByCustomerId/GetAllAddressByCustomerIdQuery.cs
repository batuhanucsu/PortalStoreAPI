using MediatR;
using PortalStoreAPI.Application.Dto;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.AddressOperaions.Queries.GetAllAdressesByCustomerId
{
    public class GetAllAddressByCustomerIdQuery : IRequest<ServiceResponse<List<AddressViewDto>>>
    {
        public int CustomerId { get; set; }
    }
}
