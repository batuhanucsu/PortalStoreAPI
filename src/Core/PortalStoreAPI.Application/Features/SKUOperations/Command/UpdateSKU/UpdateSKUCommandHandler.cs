using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.UpdateSKU
{
    public class UpdateSKUCommandHandler : IRequestHandler<UpdateSKUCommand, ServiceResponse<string>>
    {
        ISKURepository _sKURepository;
        IMapper _mapper;

        public UpdateSKUCommandHandler(ISKURepository sKURepository, IMapper mapper)
        {
            _sKURepository = sKURepository;
            _mapper = mapper;
        }
    
        public async Task<ServiceResponse<string>> Handle(UpdateSKUCommand request, CancellationToken cancellationToken)
        {
            var updatedSKU = await _sKURepository.GetByIdAsync(request.Id);

            if(updatedSKU is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedSKU.Id= request.Id;
            updatedSKU.Name = updatedSKU.Name != default ? request.Name : updatedSKU.Name;
            updatedSKU.Description = updatedSKU.Description != default ? request.Description : updatedSKU.Description;
            updatedSKU.OldPrice = updatedSKU.OldPrice != default ? request.OldPrice : updatedSKU.OldPrice;
            updatedSKU.Price = updatedSKU.Price != default ? request.Price : updatedSKU.Price;
            updatedSKU.Status = request.Status;
            updatedSKU.CreationDate = DateTime.Now;

            await _sKURepository.UpdateAsync(updatedSKU);
            return new ServiceResponse<string>("SKU is updated.");

        }
    }
}
