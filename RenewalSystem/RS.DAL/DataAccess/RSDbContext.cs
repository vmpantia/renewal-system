using Microsoft.EntityFrameworkCore;
using RS.DAL.DataAccess.Entities;

namespace RS.DAL.DataAccess
{
    public class RSDbContext : DbContext
    {
        public RSDbContext(DbContextOptions options) : base(options) { }

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
