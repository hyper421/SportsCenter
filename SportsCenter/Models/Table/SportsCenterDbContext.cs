using Microsoft.EntityFrameworkCore;

namespace SportsCenter.Models.Table
{
    public class SportsCenterDbContext :DbContext
    {
        public SportsCenterDbContext(DbContextOptions<SportsCenterDbContext> options) : base(options) { }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsOrder> ProductsOrder { get; set; }
    }
}

