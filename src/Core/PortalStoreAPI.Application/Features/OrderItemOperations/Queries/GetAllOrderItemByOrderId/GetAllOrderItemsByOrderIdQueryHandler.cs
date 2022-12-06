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

namespace PortalStoreAPI.Application.Features.OrderItemOperations.Queries.GetAllOrderItemByOrderId
{
    public class GetAllOrderItemsByOrderIdQueryHandler : IRequestHandler<GetAllOrderItemsByOrderIdQuery, ServiceResponse<List<OrderItemViewDto>>>
    {
        IOrderItemRepository _orderItemRepository;
        IMapper _mapper;
        public GetAllOrderItemsByOrderIdQueryHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<OrderItemViewDto>>> Handle(GetAllOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var allList = await _orderItemRepository.GetAllAsync(x => x.OrderId == request.OrderId);
            var viewModel = _mapper.Map<List<OrderItemViewDto>>(allList);
            return new ServiceResponse<List<OrderItemViewDto>>(viewModel);
        }
    }
}
