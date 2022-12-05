using MediatR;
using PortalStoreAPI.Application.Dto;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.UpdateSKU
{
    public class UpdateSKUCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
    }
}
