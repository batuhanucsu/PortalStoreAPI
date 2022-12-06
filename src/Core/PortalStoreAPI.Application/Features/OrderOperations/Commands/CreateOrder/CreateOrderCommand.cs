using MediatR;
using PortalStoreAPI.Domain.Entities;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<ServiceResponse<string>>
    {
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public int TotalPrice { get; set; }
    }
}
