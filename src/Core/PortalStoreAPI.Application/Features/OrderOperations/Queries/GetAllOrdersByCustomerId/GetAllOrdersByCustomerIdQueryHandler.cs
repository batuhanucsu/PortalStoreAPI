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

namespace PortalStoreAPI.Application.Features.OrderOperations.Queries.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdQueryHandler : IRequestHandler<GetAllOrdersByCustomerIdQuery, ServiceResponse<List<OrderViewDto>>>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public GetAllOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<OrderViewDto>>> Handle(GetAllOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var allList = await _orderRepository.GetAllAsync(x => x.CustomerId == request.CustomerId);
            var viewModel = _mapper.Map<List<OrderViewDto>>(allList);
            return new ServiceResponse<List<OrderViewDto>>(viewModel);
        }
    }
}
