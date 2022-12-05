using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<ServiceResponse<string>>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
    }
}
