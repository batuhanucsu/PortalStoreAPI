using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<string>>
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (updatedCategory is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedCategory.Id = request.Id;
            updatedCategory.Name = updatedCategory.Name != default ? request.Name : updatedCategory.Name;
            updatedCategory.Status = request.Status;
            updatedCategory.CreationDate = DateTime.Now;

            await _categoryRepository.UpdateAsync(updatedCategory);
            return new ServiceResponse<string>("Category is updated.");
        }
    }
}
