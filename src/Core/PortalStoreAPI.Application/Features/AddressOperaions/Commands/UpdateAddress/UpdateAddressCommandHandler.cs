using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.AddressOperaions.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ServiceResponse<string>>
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var updatedAddress = await _addressRepository.GetByIdAsync(request.Id);

            if (updatedAddress is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedAddress.Id = request.Id;
            updatedAddress.AddressLine = updatedAddress.AddressLine != default ? request.AddressLine : updatedAddress.AddressLine;
            updatedAddress.Country = updatedAddress.Country != default ? request.Country : updatedAddress.Country;
            updatedAddress.City = updatedAddress.City != default ? request.City : updatedAddress.City;
            updatedAddress.District = updatedAddress.District != default ? request.District : updatedAddress.District;
            updatedAddress.ZipCode = updatedAddress.ZipCode != default ? request.ZipCode : updatedAddress.ZipCode;

            updatedAddress.Status = updatedAddress.Status;
            updatedAddress.CreationDate = DateTime.Now;

            await _addressRepository.UpdateAsync(updatedAddress);
            return new ServiceResponse<string>("Address is updated.");
        }
    }
}
