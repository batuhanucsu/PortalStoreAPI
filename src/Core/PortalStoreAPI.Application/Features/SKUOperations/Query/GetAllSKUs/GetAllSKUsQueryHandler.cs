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

namespace PortalStoreAPI.Application.Features.SKUOperations.Query.GetAllSKUs
{
    public class GetAllSKUsQueryHandler : IRequestHandler<GetAllSKUsQuery, ServiceResponse<List<SKUViewDto>>>
    {
        private readonly ISKURepository _sKURepository;
        private readonly IMapper _mapper;

        public GetAllSKUsQueryHandler(ISKURepository sKURepository, IMapper mapper)
        {
            _sKURepository = sKURepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<SKUViewDto>>> Handle(GetAllSKUsQuery request, CancellationToken cancellationToken)
        {
            var allList = await _sKURepository.GetAllAsync();
            var viewModel = _mapper.Map<List<SKUViewDto>>(allList);
            return new ServiceResponse<List<SKUViewDto>>(viewModel);
        }
    }
}
