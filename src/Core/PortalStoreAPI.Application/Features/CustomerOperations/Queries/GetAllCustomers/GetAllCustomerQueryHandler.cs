using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Dto;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CustomerOperations.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ServiceResponse<List<CustomerViewDto>>>
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async  Task<ServiceResponse<List<CustomerViewDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = await _customerRepository.GetAllAsync();
            var viewModel = _mapper.Map<List<CustomerViewDto>>(allCustomers);
            return new ServiceResponse<List<CustomerViewDto>>(viewModel);
        }
    }
}
