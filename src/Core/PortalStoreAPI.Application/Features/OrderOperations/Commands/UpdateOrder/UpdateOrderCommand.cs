using MediatR;
using PortalStoreAPI.Domain.Entities;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
        public int AddressId { get; set; }

    }
}
