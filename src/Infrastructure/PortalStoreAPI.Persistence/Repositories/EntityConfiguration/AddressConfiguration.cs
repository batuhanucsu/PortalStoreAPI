
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Persistence.Repositories.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressLine).HasMaxLength(250);
            builder.Property(x => x.Country).HasMaxLength(30);
            builder.Property(x => x.City).HasMaxLength(30);
            builder.Property(x => x.District).HasMaxLength(30);
        }
    }
}
