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

namespace PortalStoreAPI.Application.Features.AddressOperaions.Queries.GetAllAdressesByCustomerId
{
    public class GetAllAddressByCustomerIdQueryHandler : IRequestHandler<GetAllAddressByCustomerIdQuery, ServiceResponse<List<AddressViewDto>>>
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;

        public GetAllAddressByCustomerIdQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
           
        }
        public async Task<ServiceResponse<List<AddressViewDto>>> Handle(GetAllAddressByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var allList = await _addressRepository.GetAllAsync(x => x.CustomerId == request.CustomerId);
            var viewModel = _mapper.Map<List<AddressViewDto>>(allList);
            return new ServiceResponse<List<AddressViewDto>>(viewModel);
        }
    }
}
