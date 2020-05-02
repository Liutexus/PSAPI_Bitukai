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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
