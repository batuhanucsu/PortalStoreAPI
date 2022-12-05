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

namespace PortalStoreAPI.Application.Features.SKUOperations.Query.GetSKUById
{
    public class GetSKUByIdQueryHandler : IRequestHandler<GetSKUByIdQuery, ServiceResponse<SKUViewDto>>
    {
        
        ISKURepository _sKURepository;
        IMapper _mapper;

        public GetSKUByIdQueryHandler(ISKURepository sKURepository, IMapper mapper)
        {
            _sKURepository = sKURepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SKUViewDto>> Handle(GetSKUByIdQuery request, CancellationToken cancellationToken)
        {

            var sku = await _sKURepository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<SKUViewDto>(sku);

            return new ServiceResponse<SKUViewDto>(dto);
        }
    }
}
