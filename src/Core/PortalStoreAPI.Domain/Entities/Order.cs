using PortalStoreAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Address Address { get; set; }
        public int AddressId { get; set; }

        public int TotalPrice { get; set; }

        public List<OrderItem> ? OrderItems { get; set; }

    }
}
