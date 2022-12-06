using AutoMapper;
using PortalStoreAPI.Application.Dto;
using PortalStoreAPI.Application.Features.AddressOperaions.Commands.CreateAddress;
using PortalStoreAPI.Application.Features.CategoryOperations.Commands.CreateCategory;
using PortalStoreAPI.Application.Features.CustomerOperations.Commands.CreateCustomer;
using PortalStoreAPI.Application.Features.OrderItemOperations.Commands.CreateOrderItem;
using PortalStoreAPI.Application.Features.OrderOperations.Commands.CreateOrder;
using PortalStoreAPI.Application.Features.SKUOperations.Command.CreateSKU;
using PortalStoreAPI.Application.Features.SKUOperations.Command.UpdateSKU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping()
        {
            CreateMap<PortalStoreAPI.Domain.Entities.SKU,SKUViewDto>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.SKU, CreateSKUCommand>().ReverseMap(); 
            CreateMap<PortalStoreAPI.Domain.Entities.SKU, UpdateSKUCommand>().ReverseMap(); 

            CreateMap<PortalStoreAPI.Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.Category, CategoryViewDto>().ReverseMap();

            CreateMap<PortalStoreAPI.Domain.Entities.Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.Customer, CustomerViewDto>().ReverseMap();


            CreateMap<PortalStoreAPI.Domain.Entities.Order, CreateOrderCommand>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.Order, OrderViewDto>().ReverseMap();


            CreateMap<PortalStoreAPI.Domain.Entities.OrderItem, CreateOrderItemCommand>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.OrderItem, OrderItemViewDto>().ReverseMap();


            CreateMap<PortalStoreAPI.Domain.Entities.Address, CreateAddressCommand>().ReverseMap();
            CreateMap<PortalStoreAPI.Domain.Entities.Address, AddressViewDto>().ReverseMap();






        }

    }
}
