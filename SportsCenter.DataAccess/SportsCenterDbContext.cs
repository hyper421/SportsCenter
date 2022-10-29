using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.DataAccess
{
    public class SportsCenterDbContext:DbContext
    {
        public SportsCenterDbContext(DbContextOptions<SportsCenterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationBranch> LocationBranch { get; set; }
        public virtual DbSet<LocationImage> LocationImage { get; set; }
        public virtual DbSet<LocationOrder> LocationOrder { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsCart> ProductsCart { get; set; }
        public virtual DbSet<ProductsOrder> ProductsOrder { get; set; }
        public virtual DbSet<ProductsOrderDetail> ProductsOrderDetail { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<InviteCategory> InviteCategory { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Area).IsRequired();

                entity.Property(e => e.ContactPhone).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EnglishName).IsRequired();

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Website).IsRequired();
            });

            modelBuilder.Entity<LocationBranch>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_LocationBranch_Category_Id");

                entity.HasIndex(e => e.LocationId, "IX_LocationBranch_Location_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.LocationId).HasColumnName("Location_Id");

                entity.Property(e => e.Memo).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LocationBranch)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationBranch)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<LocationImage>(entity =>
            {
                entity.HasIndex(e => e.LocationId, "IX_LocationImage_Location_Id");

                entity.Property(e => e.LocationId).HasColumnName("Location_Id");

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationImage)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<LocationOrder>(entity =>
            {
                entity.HasIndex(e => e.LocationBranchId1, "IX_LocationOrder_LocationBranchId");

                entity.HasIndex(e => e.LocationBranchId, "IX_LocationOrder_LocationBranch_Id");

                entity.HasIndex(e => e.MemberId, "IX_LocationOrder_Member_Id");

                entity.Property(e => e.LocationBranchId).HasColumnName("LocationBranch_Id");

                entity.Property(e => e.LocationBranchId1).HasColumnName("LocationBranchId");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.LocationBranch)
                    .WithMany(p => p.LocationOrder)
                    .HasForeignKey(d => d.LocationBranchId);

                entity.HasOne(d => d.LocationBranchId1Navigation)
                    .WithMany(p => p.LocationOrder)
                    .HasForeignKey(d => d.LocationBranchId1);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.LocationOrder)
                    .HasForeignKey(d => d.MemberId);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Salt).HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.ItemId, "IX_Products_Item_Id");

                entity.Property(e => e.ProductsId).HasColumnName("Products_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.ProductsDateTime).HasColumnName("Products_DateTime");

                entity.Property(e => e.ProductsImagePath)
                    .IsRequired()
                    .HasColumnName("Products_ImagePath");

                entity.Property(e => e.ProductsInventory).HasColumnName("Products_Inventory");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Products_Name");

                entity.Property(e => e.ProductsPrice).HasColumnName("Products_Price");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<ProductsCart>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_ProductsCart_Member_Id");

                entity.HasIndex(e => e.ProductsId, "IX_ProductsCart_Products_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.ProductsId).HasColumnName("Products_Id");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ProductsCart)
                    .HasForeignKey(d => d.MemberId);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.ProductsCart)
                    .HasForeignKey(d => d.ProductsId);
            });

            modelBuilder.Entity<ProductsOrder>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_ProductsOrder_Member_Id");

                entity.Property(e => e.MemberAddress)
                    .IsRequired()
                    .HasColumnName("Member_Address");

                entity.Property(e => e.MemberCellphone)
                    .IsRequired()
                    .HasColumnName("Member_Cellphone");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ProductsOrder)
                    .HasForeignKey(d => d.MemberId);
            });

            modelBuilder.Entity<ProductsOrderDetail>(entity =>
            {
                entity.HasIndex(e => e.ProductOrderId, "IX_ProductsOrderDetail_ProductOrderId");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductsPrice).HasColumnName("Products_Price");

                entity.HasOne(d => d.ProductOrder)
                    .WithMany(p => p.ProductsOrderDetail)
                    .HasForeignKey(d => d.ProductOrderId);
            });
            modelBuilder.Entity<InviteCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Posts).WithOne(e => e.InviteCategory).HasForeignKey(e => e.InviteCategory_Id);
                
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Message).WithOne(x => x.Post);
                entity.HasOne(e => e.Member).WithMany(e => e.Post).HasForeignKey(e => e.Member_Id);
                entity.HasOne(e => e.InviteCategory).WithMany(e => e.Posts).HasForeignKey(e => e.InviteCategory_Id);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Member).WithMany(e => e.Messages).HasForeignKey(e => e.Member_Id);
                entity.HasOne(e => e.Post).WithMany(e => e.Message).HasForeignKey(e => e.Post_Id);
            });

            
        }
    }
}
