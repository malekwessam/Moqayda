using Microsoft.EntityFrameworkCore;
using Moqayda.API.Entities;

namespace Moqayda.API.Data
{
    public class MoqaydaDbContext:DbContext
    {
        public MoqaydaDbContext(DbContextOptions<MoqaydaDbContext> options):base(options) 
        {
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOwner> ProductOwner { get; set; }
        public DbSet<WishlistItem> WishlistItem { get; set; }


        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Category>()
                .HasMany(b => b.Product)
                .WithOne(b => b.Category)
                .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<Product>()
                .HasMany(b=>b.WishlistItem)
                .WithOne(b=>b.Product)
               .OnDelete(DeleteBehavior.Cascade);
        }

       
    }
   
}
