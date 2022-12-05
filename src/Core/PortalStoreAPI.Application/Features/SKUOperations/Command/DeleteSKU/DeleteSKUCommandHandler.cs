using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.DeleteSKU
{
    public class DeleteSKUCommandHandler : IRequestHandler<DeleteSKUCommand, ServiceResponse<string>>
    {
        ISKURepository _sKURepository;
        IMapper _mapper;

        public DeleteSKUCommandHandler(ISKURepository sKURepository, IMapper mapper)
        {
            _sKURepository = sKURepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(DeleteSKUCommand request, CancellationToken cancellationToken)
        {
            var deletedSKU = await _sKURepository.GetByIdAsync(request.Id);
            if(deletedSKU is null)
            {
                throw new Exception("Deleted SKU is not found.");
            }
            await _sKURepository.DeleteAsync(deletedSKU);

            return new ServiceResponse<string>("SKU is deleted.");

        }
    }
}
