using PortalStoreAPI.Application.Interfaces.Repository;
using PortalStoreAPI.Application.Persistence.EntityFramework;
using PortalStoreAPI.Domain.Entities;
using PortalStoreAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Persistence.Repositories
{
    public class AddressRepository : EFEntityRepositoryBase<Address,PortalStoreAPIDbContext>,IAddressRepository
    {
       
    }
}
