using AutoMapper;
using MediatR;
using PortalStoreAPI.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Features.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<string>>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request.Status = true;
            request.CreationDate = DateTime.Now;
            var order = _mapper.Map<Domain.Entities.Order>(request);
            await _orderRepository.AddAsync(order);
            return new ServiceResponse<string>("Order is created.");
        }
    }
}
