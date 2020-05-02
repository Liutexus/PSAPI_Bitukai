using System.Collections.Generic;
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
                AlternativeIds = string.Empty,
                CoreClockGhz = 2.3f,
                IntegratedGpu = "Gpu",
                CoreCount = 4,
                Socket = "AM4",
                Tdp = 3.4
            };
            var processors = new List<Processor>()
            {
                processor,
                new Processor
                {

                    Id = 2,
                    Manufacturer = "AMD",
                    Name = "Ryzen 7 3700",
                    AlternativeIds = "1",
                    CoreClockGhz = 3.7f,
                    IntegratedGpu = "Gpu",
                    CoreCount = 8,
                    Socket = "AM4",
                    Tdp = 3.4
                }
            };
            builder.Entity<Processor>().HasData(processors);
        }
    }
}
