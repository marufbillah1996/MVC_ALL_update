using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models
{
    
    //public class CustomInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    //{
    //    public void InitializeDatabase(TContext context)
    //    {
    //        var initializer = new MigrateDatabaseToLatestVersion<TContext, DbMigrationsConfiguration<TContext>>();
    //        initializer.InitializeDatabase(context);
    //    }
    //}
    public class ProductDbContext:DbContext
    {
        
        public ProductDbContext()
            : base("name=db")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductDbContext>());

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.OrderDetails)
            //    .WithRequired(e => e.Product)
            //    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierCategory>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.SupplierCategory)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.PurchaseDetails)
                .WithRequired(e => e.Purchase)
                .WillCascadeOnDelete(false);
        }
    }
}