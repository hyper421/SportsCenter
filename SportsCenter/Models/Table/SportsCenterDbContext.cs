using Microsoft.EntityFrameworkCore;

namespace SportsCenter.Models.Table
{
    public class SportsCenterDbContext :DbContext
    {
        public SportsCenterDbContext(DbContextOptions<SportsCenterDbContext> options) : base(options) { }
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationImage> LocationImage { get; set; }
        public DbSet<LocationBranch> LocationBranch { get; set; }
        public DbSet<LocationOrder> LocationOrder { get; set; }
        public DbSet<ProductsOrderDetail> ProductsOrderDetail { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsCart> ProductsCart { get; set; }
        public DbSet<ProductsOrder> ProductsOrder { get; set; }
    }
}

