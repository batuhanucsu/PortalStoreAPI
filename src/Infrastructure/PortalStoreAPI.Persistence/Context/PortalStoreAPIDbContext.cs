using Microsoft.EntityFrameworkCore;
using PortalStoreAPI.Domain.Entities;
using PortalStoreAPI.Persistence.Repositories.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Persistence.Context
{
    public class PortalStoreAPIDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KVH74IN\SQLEXPRESS;Database=PortalStoreDB;Trusted_Connection=true;Encrypt=False;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new SKUConfiguration());

            //SKU-Category
            modelBuilder.Entity<SKU>().HasOne(i => i.Category).WithMany(p => p.SKUs).HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);

            //SKU-OrderItem
            modelBuilder.Entity<OrderItem>().HasOne(i => i.SKU).WithMany(p => p.OrderItems).HasForeignKey(i => i.SkuId).OnDelete(DeleteBehavior.ClientSetNull);

            //OrderItem-Order
            modelBuilder.Entity<OrderItem>().HasOne(i => i.Order).WithMany(p => p.OrderItems).HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.ClientSetNull);

            //Order-Customer
            modelBuilder.Entity<Order>().HasOne(i => i.Customer).WithMany(p => p.Orders).HasForeignKey(i => i.CustomerId).OnDelete(DeleteBehavior.ClientSetNull);

            //Order-Address
            modelBuilder.Entity<Order>().HasOne(i => i.Address).WithMany(p => p.Orders).HasForeignKey(i => i.AddressId).OnDelete(DeleteBehavior.ClientSetNull);

            //Customer-Address
            modelBuilder.Entity<Address>().HasOne(i => i.Customer).WithMany(p => p.Addresses).HasForeignKey(i => i.CustomerId).OnDelete(DeleteBehavior.ClientSetNull);

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SKU> SKUs { get; set; }
    }
}
