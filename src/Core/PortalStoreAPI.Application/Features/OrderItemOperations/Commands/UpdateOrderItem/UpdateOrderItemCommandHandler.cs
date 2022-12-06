using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, ServiceResponse<string>>
    {
        IOrderItemRepository _orderItemRepository;
        IMapper _mapper;
        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var updatedOrderItem = await _orderItemRepository.GetByIdAsync(request.Id);

            if (updatedOrderItem is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedOrderItem.Id = request.Id;
            updatedOrderItem.Quantity = updatedOrderItem.Quantity != default ? request.Quantity : updatedOrderItem.Quantity;

            await _orderItemRepository.UpdateAsync(updatedOrderItem);
            return new ServiceResponse<string>("OrderItem is updated.");
        }
    }
}
