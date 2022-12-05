using AutoMapper;
using PortalStoreAPI.Application.Dto;
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

        }

    }
}
