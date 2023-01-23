using Microsoft.EntityFrameworkCore;

namespace GeekShop.CartApi.Model.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartHeader> CartHeaders => Set<CartHeader>();
        public DbSet<CartDetail> CartDetails => Set<CartDetail>();
    }
}
