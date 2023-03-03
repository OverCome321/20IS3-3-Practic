using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
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
                entity.HasKey(e => e.IdCart)
                    .HasName("PK__Carts__C71FE317B0A83689");

                entity.Property(e => e.IdCart)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cart");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carts_Users1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategories)
                    .HasName("PK__Categori__4E9B0F3422074056");

                entity.Property(e => e.IdCategories)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categories");

                entity.Property(e => e.CategorieName)
                    .HasMaxLength(100)
                    .HasColumnName("categorie_name");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Orders__DD5B8F3F5DEA492A");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("order_date");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Statuses");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.IdOrderItem)
                    .HasName("PK__Order_it__2453F01211014C4B");

                entity.ToTable("Order_items");

                entity.Property(e => e.IdOrderItem)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order_item");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_items_Orders");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_items_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__BA39E84FD95ACA34");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_product");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.IdCategories).HasColumnName("id_categories");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("price");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategories)
                    .HasConstraintName("FK__Products__id_cat__2E1BDC42");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__3D48441DCA726BBA");

                entity.Property(e => e.IdRole)
                    .ValueGeneratedNever()
                    .HasColumnName("id_role");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<SpecProduct>(entity =>
            {
                entity.HasKey(e => e.IdSpecProduct)
                    .HasName("PK__Spec_Pro__DFF7AFD1958AB5A4");

                entity.ToTable("Spec_Products");

                entity.Property(e => e.IdSpecProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_spec_product");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdSpecification).HasColumnName("id_specification");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.SpecProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__Spec_Prod__id_pr__33D4B598");

                entity.HasOne(d => d.IdSpecificationNavigation)
                    .WithMany(p => p.SpecProducts)
                    .HasForeignKey(d => d.IdSpecification)
                    .HasConstraintName("FK__Spec_Prod__id_sp__32E0915F");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.IdSpecification)
                    .HasName("PK__Specific__9AA1849CDCF88FE3");

                entity.Property(e => e.IdSpecification)
                    .ValueGeneratedNever()
                    .HasColumnName("id_specification");

                entity.Property(e => e.IdCategories).HasColumnName("id_categories");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.SpecName)
                    .HasMaxLength(100)
                    .HasColumnName("spec_name");

                entity.Property(e => e.SpecValue).HasColumnName("spec_value");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.IdCategories)
                    .HasConstraintName("FK__Specifica__id_ca__25869641");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Statuses__5D2DC6E828C69E2B");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_status");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(100)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D146372B398BFC");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IsDeleated).HasColumnName("is_deleated");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("registration_date");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
