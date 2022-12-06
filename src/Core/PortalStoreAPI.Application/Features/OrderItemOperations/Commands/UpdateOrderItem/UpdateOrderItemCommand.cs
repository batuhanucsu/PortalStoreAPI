using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
