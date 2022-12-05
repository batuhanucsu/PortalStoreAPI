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

namespace PortalStoreAPI.Application.Features.SKUOperations.Command.CreateSKU
{
    public class CreateSKUCommandHandler : IRequestHandler<CreateSKUCommand, ServiceResponse<string>>
    {
        ISKURepository _sKURepository;
        IMapper _mapper;

        public CreateSKUCommandHandler(ISKURepository sKURepository, IMapper mapper)
        {
            _sKURepository = sKURepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateSKUCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var sku = _mapper.Map<Domain.Entities.SKU>(request);
            await _sKURepository.AddAsync(sku);
            return new ServiceResponse<string>("SKU is created.");

        }
    }
}
