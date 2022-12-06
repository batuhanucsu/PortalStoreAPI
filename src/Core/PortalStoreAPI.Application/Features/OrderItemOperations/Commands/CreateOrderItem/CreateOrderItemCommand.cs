using MediatR;
using PortalStoreAPI.Domain.Entities;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<ServiceResponse<string>>
    {
        public int SkuId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
