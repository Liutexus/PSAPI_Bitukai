using Bitukai.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bitukai.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Component> Comments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComponentCart> ComponentCarts { get; set; }
        public DbSet<UserFavoriteComponent> UserFavoriteComponents { get; set; }
        public DbSet<Bitukai.Models.Comment> Comment { get; set; }
        public DbSet<User> UsersDb { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ComponentCart>().HasKey(cc => new { cc.ComponentId, cc.CartId });
            builder.Entity<ComponentCart>()
                .HasOne<Component>(sc => sc.Component)
                .WithMany(s => s.ComponentCarts)
                .HasForeignKey(sc => sc.ComponentId);

            builder.Entity<ComponentCart>()
                .HasOne<Cart>(sc => sc.Cart)
                .WithMany(s => s.ComponentCarts)
                .HasForeignKey(sc => sc.CartId);

            builder.Entity<UserFavoriteComponent>().HasKey(cc => new { cc.ComponentId, cc.UserId });
            builder.Entity<UserFavoriteComponent>()
                .HasOne<Component>(sc => sc.Component)
                .WithMany(s => s.FavoriteComponents)
                .HasForeignKey(sc => sc.ComponentId);

            builder.Entity<UserFavoriteComponent>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.FavoriteComponents)
                .HasForeignKey(sc => sc.UserId);

            base.OnModelCreating(builder);
            Seed.SeedData(builder);
        }
    }
}
