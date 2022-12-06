using PortalStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Dto
{
    public class OrderViewDto
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public int TotalPrice { get; set; }
    }
}
