using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<string>>
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var category = _mapper.Map<Domain.Entities.Category>(request);
            await _categoryRepository.AddAsync(category);
            return new ServiceResponse<string>("Category is created.");
        }
    }
}
