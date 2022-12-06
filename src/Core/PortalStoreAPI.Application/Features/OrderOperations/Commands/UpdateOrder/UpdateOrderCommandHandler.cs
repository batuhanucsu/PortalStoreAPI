using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ServiceResponse<string>>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var updatedOrder = await _orderRepository.GetByIdAsync(request.Id);

            if (updatedOrder is null)
            {
                throw new Exception("Object is not found.");
            }

            updatedOrder.Id = request.Id;
            updatedOrder.AddressId = updatedOrder.AddressId != default ? request.AddressId : updatedOrder.AddressId;

            await _orderRepository.UpdateAsync(updatedOrder);
            return new ServiceResponse<string>("Order is updated.");
        }
    }
}
