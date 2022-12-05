using PortalStoreAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long  TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gsm { get; set; }

        public List<Address> ? Addresses { get; set; }
        public List<Order> ? Orders { get; set; }

    }
}
