using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> dbContextoptions) : base(dbContextoptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty { Id = Guid.Parse("979b4832-d2e2-4d4e-9f4e-8a6503a8f017"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("90f365ab-d024-4384-b3d5-058cb3918803"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("6ae01c02-521c-434e-8eaf-ab6d06e71bce"), Name = "Hard" }
            );

            // Seed data for regions
            modelBuilder.Entity<Regions>().HasData(
                new Regions
                {
                    Id = Guid.Parse("81a73776-64b9-45c3-bcfa-5805788c93cd"),
                    Name = "Auckland",
                    Code = "ACK",
                    RegionImageUrl = "https://example.com/images/auckland.jpg"
                }
            );
        }
    }
}
