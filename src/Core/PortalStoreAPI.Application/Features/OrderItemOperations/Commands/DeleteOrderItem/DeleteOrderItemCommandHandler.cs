using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, ServiceResponse<string>>
    {
        IOrderItemRepository _orderItemRepository;
        IMapper _mapper;
        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var deletedOrderItem = await _orderItemRepository.GetByIdAsync(request.Id);
            if (deletedOrderItem is null)
            {
                throw new Exception("Deleted OrderItem is not found.");
            }
            await _orderItemRepository.DeleteAsync(deletedOrderItem);

            return new ServiceResponse<string>("OrderItem is deleted.");
        }
    }
}
