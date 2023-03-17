using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practic_Api_1.Models
{
    public partial class WebShopContext : DbContext
    {
        public WebShopContext()
        {
        }

        public WebShopContext(DbContextOptions<WebShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SpecProduct> SpecProducts { get; set; } = null!;
        public virtual DbSet<Specification> Specifications { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Cart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_User1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DeliveryType>(entity =>
            {
                entity.ToTable("DeliveryType");

                entity.Property(e => e.DeliveryTypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.DeliveryType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Order");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Statuses");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemsId)
                    .HasName("PK__OrderIte__D5BB2555696A45F2");

                entity.Property(e => e.OrderItemsId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_item_Orders");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_items_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductsId)
                    .HasName("PK__Products__BB48EDE5F7A989D5");

                entity.Property(e => e.ProductsId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__3B75D760");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<SpecProduct>(entity =>
            {
                entity.HasKey(e => e.SpecProdId)
                    .HasName("PK__Spec_Pro__BDDD4ED62622994D");

                entity.ToTable("Spec_Products");

                entity.Property(e => e.SpecProdId).ValueGeneratedNever();

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.SpecProducts)
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("FK__Spec_Prod__Produ__3C69FB99");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecProducts)
                    .HasForeignKey(d => d.SpecId)
                    .HasConstraintName("FK__Spec_Prod__SpecI__3D5E1FD2");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK__Specific__883D567BF14A1933");

                entity.ToTable("Specification");

                entity.Property(e => e.SpecId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Specifica__Categ__3E52440B");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Adress).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
