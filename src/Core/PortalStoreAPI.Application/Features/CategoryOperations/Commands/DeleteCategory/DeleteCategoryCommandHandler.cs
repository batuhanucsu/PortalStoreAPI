using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<string>>
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deletedCategory = await _categoryRepository.GetByIdAsync(request.Id);
            if (deletedCategory is null)
            {
                throw new Exception("Deleted Category is not found.");
            }
            await _categoryRepository.DeleteAsync(deletedCategory);

            return new ServiceResponse<string>("Category is deleted.");

        }
    }
}
