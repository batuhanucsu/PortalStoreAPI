using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.AddressOperaions.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, ServiceResponse<string>>
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var address = _mapper.Map<Domain.Entities.Address>(request);
            await _addressRepository.AddAsync(address);
            return new ServiceResponse<string>("Address is created.");
        }
    }
}
