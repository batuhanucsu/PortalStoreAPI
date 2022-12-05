using PortalStoreAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Domain.Entities
{
    public class SKU : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<OrderItem> ? OrderItems { get; set; }

    }
}
