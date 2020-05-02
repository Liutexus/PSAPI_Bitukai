using System.Linq;
using Bitukai.Models;
using Microsoft.EntityFrameworkCore;

namespace Bitukai.Data
{
    public static class Seed
    {
        public static void SeedData(ModelBuilder builder)
        {
            var processor = new Processor
            {
                Id = 1,
                Manufacturer = "Intel",
                Name = "Core i5-2134",
                CoreClockGhz = 2.3f,
                IntegratedGpu = "Gpu",
                CoreCount = 4,
                Socket = "AM4",
                Tdp = 3.4
            };
            builder.Entity<Processor>().HasData(processor);
        }
    }
}
