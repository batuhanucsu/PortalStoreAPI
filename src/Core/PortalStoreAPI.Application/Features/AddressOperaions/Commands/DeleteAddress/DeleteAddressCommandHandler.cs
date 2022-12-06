using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.AddressOperaions.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ServiceResponse<string>>
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var deletedAddress = await _addressRepository.GetByIdAsync(request.Id);
            if (deletedAddress is null)
            {
                throw new Exception("Deleted Address is not found.");
            }
            await _addressRepository.DeleteAsync(deletedAddress);

            return new ServiceResponse<string>("Address is deleted.");
        }
    }
}
