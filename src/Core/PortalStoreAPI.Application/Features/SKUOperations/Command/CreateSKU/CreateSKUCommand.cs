using MediatR;
using PortalStoreAPI.Application.Dto;
using PortalStoreAPI.Domain.Entities;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.CreateSKU
{
    public class CreateSKUCommand : IRequest<ServiceResponse<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
