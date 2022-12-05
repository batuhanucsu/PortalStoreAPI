using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ServiceResponse<string>>
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var updatedCustomer = await _customerRepository.GetByIdAsync(request.Id);

            if (updatedCustomer is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedCustomer.Id = request.Id;
            updatedCustomer.Email = updatedCustomer.Email != default ? request.Email : updatedCustomer.Email;
            updatedCustomer.Gsm = updatedCustomer.Gsm != default ? request.Gsm : updatedCustomer.Gsm;
            await _customerRepository.UpdateAsync(updatedCustomer);
            return new ServiceResponse<string>("Customer is updated.");
        }
    }
}
