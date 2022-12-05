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

namespace PortalStoreAPI.Application.Features.CategoryOperations.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ServiceResponse<List<CategoryViewDto>>>
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CategoryViewDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allCategoriest = await _categoryRepository.GetAllAsync();
            var viewModel = _mapper.Map<List<CategoryViewDto>>(allCategoriest);
            return new ServiceResponse<List<CategoryViewDto>>(viewModel);
        }
    }
}
