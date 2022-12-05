using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PortalStoreAPI.Persistence.Repositories.EntityConfiguration
{
    public class SKUConfiguration : IEntityTypeConfiguration<SKU>
    {
        public void Configure(EntityTypeBuilder<SKU> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.OldPrice).HasPrecision(16, 2);
            builder.Property(x => x.Price).HasPrecision(16, 2);

        }
    }
}
