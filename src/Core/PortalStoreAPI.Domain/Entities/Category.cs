using PortalStoreAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<SKU> ? SKUs { get; set; }
    }
}
