using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleID = "324e7347-e8a0-445f-842b-3b19a81e7ded";
            var writerRoleId = "a6482509-00bf-4671-a07f-51672e4fd151";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {

                Id = readerRoleID,
                ConcurrencyStamp = readerRoleID,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
                },

                 new IdentityRole
                 {

                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    
    }
}
