using Microsoft.EntityFrameworkCore;
using RS.DAL.DataAccess.Entities;

namespace RS.DAL.DataAccess
{
    public class RSDbContext : DbContext
    {
        public RSDbContext(DbContextOptions<RSDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(data => data.Subscriptions)
                .WithOne(data => data.Customer)
                .HasForeignKey(data => data.CustomerId);

            modelBuilder.Entity<Product>()
                .HasMany(data => data.Subscriptions)
                .WithOne(data => data.Product)
                .HasForeignKey(data => data.ProductId);

            modelBuilder.Entity<Subscription>()
                .HasOne(data => data.Product)
                .WithMany(data => data.Subscriptions)
                .HasForeignKey(data => data.ProductId);

            modelBuilder.Entity<Subscription>()
                .HasOne(data => data.Customer)
                .WithMany(data => data.Subscriptions)
                .HasForeignKey(data => data.CustomerId);
        }
    }
}
