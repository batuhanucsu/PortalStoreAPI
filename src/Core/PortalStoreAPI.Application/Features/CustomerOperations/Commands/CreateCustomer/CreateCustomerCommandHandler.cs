using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<string>>
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var customer = _mapper.Map<Domain.Entities.Customer>(request);
            await _customerRepository.AddAsync(customer);
            return new ServiceResponse<string>("Customer is created.");
        }
    }
}
