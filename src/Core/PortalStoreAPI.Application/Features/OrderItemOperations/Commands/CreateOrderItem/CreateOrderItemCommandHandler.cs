using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ServiceResponse<string>>
    {
        IOrderItemRepository _orderItemRepository;
        IMapper _mapper;
        public CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var orderItem = _mapper.Map<Domain.Entities.OrderItem>(request);
            await _orderItemRepository.AddAsync(orderItem);
            return new ServiceResponse<string>("OrderItem is created.");
        }
    }
}
