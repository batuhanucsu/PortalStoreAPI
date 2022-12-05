using Microsoft.Extensions.DependencyInjection;
using PortalStoreAPI.Application.Interfaces.Repository;
using PortalStoreAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISKURepository,  SKURepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();



        }
    }
}
