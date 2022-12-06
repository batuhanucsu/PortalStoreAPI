using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ServiceResponse<string>>
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var deletedCustomer = await _customerRepository.GetByIdAsync(request.Id);
            if (deletedCustomer is null)
            {
                throw new Exception("Deleted Customer is not found.");
            }
            await _customerRepository.DeleteAsync(deletedCustomer);

            return new ServiceResponse<string>("Customer is deleted.");
        }
    }
}
