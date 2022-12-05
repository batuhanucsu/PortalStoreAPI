﻿using PortalStoreAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public SKU SKU { get; set; }
        public int SkuId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
