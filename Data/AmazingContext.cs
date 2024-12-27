namespace AmazingFeatures.Data
{
    public class AmazingContext : DbContext
    {
        public AmazingContext(DbContextOptions<AmazingContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
