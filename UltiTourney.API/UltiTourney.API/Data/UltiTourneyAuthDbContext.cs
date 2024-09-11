using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UltiTourney.API.Data
{
    public class UltiTourneyAuthDbContext: IdentityDbContext
    {
        public UltiTourneyAuthDbContext(DbContextOptions<UltiTourneyAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string superAdminId = "cb2c87a7-b88c-444e-b7af-deb960a2fa28"; // Full acces all app
            string adminId = "786fb16d-f678-471e-9a8b-2b3080a191e2"; // Owner from the tourney
            string scoreboardId = "624c654c-e381-4ec4-b0a6-1ccaee97d7eb"; // Edit match's result and status
            string matchManagerId = "4fec49cc-7ed1-4ab1-bda1-22761e282721"; // CRUD all matchs
            string spiritsId = "61a89ae0-f14e-45ea-be76-c417afd10201"; // Create and update own spirits
            string readerId = "282d6b15-fe08-4b35-8226-544691018d2b"; // Only read

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = superAdminId,
                    ConcurrencyStamp = superAdminId,
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = scoreboardId,
                    ConcurrencyStamp = scoreboardId,
                    Name = "Scoreboard",
                    NormalizedName = "Scoreboard".ToUpper()
                },
                new IdentityRole
                {
                    Id = matchManagerId,
                    ConcurrencyStamp = matchManagerId,
                    Name = "MatchManager",
                    NormalizedName = "MatchManager".ToUpper()
                },
                new IdentityRole
                {
                    Id = spiritsId,
                    ConcurrencyStamp = spiritsId,
                    Name = "Spirit",
                    NormalizedName = "Spirit".ToUpper()
                },
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
