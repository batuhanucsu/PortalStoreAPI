using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.AddressOperaions.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
    }
}
