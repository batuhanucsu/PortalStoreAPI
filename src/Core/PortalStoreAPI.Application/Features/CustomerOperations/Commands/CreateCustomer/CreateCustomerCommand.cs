using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<ServiceResponse<string>>
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gsm { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
