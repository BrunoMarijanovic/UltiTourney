using Microsoft.EntityFrameworkCore;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Data
{
    public class UltiTourneyDbContext: DbContext
    {
        public UltiTourneyDbContext(DbContextOptions<UltiTourneyDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tourney> Tourneys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // A city have a country and a country have many cities.
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.IdCountry);

            // A toruney have only one city
            modelBuilder.Entity<Tourney>()
                .HasOne(t => t.City)
                .WithMany()
                .HasForeignKey(t => t.IdCity);

            // A toruney have only one image
            modelBuilder.Entity<Tourney>()
                .HasOne(t => t.Image)
                .WithMany()
                .HasForeignKey(t => t.IdImage);

            base.OnModelCreating(modelBuilder);

            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.Parse("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                    Name = "España"
                },
                new Country
                {
                    Id = Guid.Parse("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                    Name = "France"
                },
                new Country
                {
                    Id = Guid.Parse("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                    Name = "Germany"
                },
                new Country
                {
                    Id = Guid.Parse("b793f8a7-7be2-4634-80da-b0d10db6b0d3"),
                    Name = "Italy"
                },
                new Country
                {
                    Id = Guid.Parse("88d9d635-e31a-4979-91f7-ef70f69c41db"),
                    Name = "Portugal"
                },
                new Country
                {
                    Id = Guid.Parse("9d64f83c-682c-4cd7-84e6-6db3c0a2d45a"),
                    Name = "United Kingdom"
                },
                new Country
                {
                    Id = Guid.Parse("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                    Name = "United States"
                },
                new Country
                {
                    Id = Guid.Parse("a8f65470-1d95-4f2e-bca0-e3b6144762aa"),
                    Name = "Canada"
                },
                new Country
                {
                    Id = Guid.Parse("7e96d6d1-ea9a-4f83-a9d9-dedb9f6dbe59"),
                    Name = "Brazil"
                },
                new Country
                {
                    Id = Guid.Parse("bc5a9391-13c0-4679-8bc7-60d6600ff621"),
                    Name = "Argentina"
                },
                new Country
                {
                    Id = Guid.Parse("5ed14b71-76f2-4d3a-8614-cf4ec2f526f2"),
                    Name = "Australia"
                },
                new Country
                {
                    Id = Guid.Parse("d196f2c8-0fc3-4965-b19c-f44e2a042dda"),
                    Name = "Japan"
                },
                new Country
                {
                    Id = Guid.Parse("68cb11c9-f00b-4665-bb7d-d9e1a0a6de27"),
                    Name = "China"
                },
                new Country
                {
                    Id = Guid.Parse("778c9814-c905-4f86-8401-8dcb9a6fbd53"),
                    Name = "India"
                },
                new Country
                {
                    Id = Guid.Parse("b7e3776f-c0f3-46ad-83b1-631b97f7fc4a"),
                    Name = "South Africa"
                },
                new Country
                {
                    Id = Guid.Parse("16d6b93f-06e5-4703-83c7-1c3e1b4c74f3"),
                    Name = "Nigeria"
                },
                new Country
                {
                    Id = Guid.Parse("1184ffed-d8c9-4544-898e-97c1e4d08f7e"),
                    Name = "Mexico"
                },
                new Country
                {
                    Id = Guid.Parse("cd16c2b9-82bb-4c18-8574-8127c5a028ec"),
                    Name = "Russia"
                },
                new Country
                {
                    Id = Guid.Parse("a7dff340-8df9-4a4c-bf49-7a70f2ef0b4e"),
                    Name = "Turkey"
                },
                new Country
                {
                    Id = Guid.Parse("21f20f48-4e37-4b0f-b845-7d3d14a0c8b2"),
                    Name = "Egypt"
                },
                new Country
                {
                    Id = Guid.Parse("9a5b5d3d-4e63-4f2e-b409-3fdbb8eaa5b9"),
                    Name = "Saudi Arabia"
                },
                new Country
                {
                    Id = Guid.Parse("b5b65a27-02ea-4c9c-9e48-1c5f5a3763d8"),
                    Name = "South Korea"
                },
                new Country
                {
                    Id = Guid.Parse("4d0fb601-e682-4fb9-b0e1-1ddac8cdb74e"),
                    Name = "Indonesia"
                },
                new Country
                {
                    Id = Guid.Parse("1198e8bb-2c49-4cb4-8cc7-7c2b9a3c4033"),
                    Name = "Thailand"
                },
                new Country
                {
                    Id = Guid.Parse("9fcbad7d-dc1a-4920-8a24-cb2b5b5cfa56"),
                    Name = "Malaysia"
                },
                new Country
                {
                    Id = Guid.Parse("4ed1d5fa-3b0d-4b82-8fd3-48235c56a22c"),
                    Name = "Singapore"
                },
                new Country
                {
                    Id = Guid.Parse("d28c5d96-23da-46fd-b59f-5eebc284fdc5"),
                    Name = "Vietnam"
                },
                new Country
                {
                    Id = Guid.Parse("da6d27f3-6213-43f2-9a5c-d6b9a324c4d3"),
                    Name = "New Zealand"
                },
                new Country
                {
                    Id = Guid.Parse("7f46b9f7-7cc5-490d-b0e1-2ef708c42e39"),
                    Name = "Chile"
                },
                new Country
                {
                    Id = Guid.Parse("27d9cbb9-c4c5-4323-83c7-fbb29a4d6c4e"),
                    Name = "Colombia"
                },
                new Country
                {
                    Id = Guid.Parse("18a9ff9b-c4ab-4074-8751-65c3e4d08f8f"),
                    Name = "Peru"
                },
                new Country
                {
                    Id = Guid.Parse("cf16c3c9-73cc-4c1f-96f5-1c7e5a0a9e4c"),
                    Name = "Venezuela"
                }
            };

            // Seed data for countries
            modelBuilder.Entity<Country>().HasData(countries);

            List<City> cities = new List<City>
            {
                new City
                {
                    Id = Guid.Parse("4b73fa7d-ffdf-4fa1-8f77-bd6459c9e91e"),
                    IdCountry = Guid.Parse("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                    Name = "Girona"
                },
                new City
                {
                    Id = Guid.Parse("39bc8a6d-87e4-45b7-8f27-7b7487e3b0e3"),
                    IdCountry = Guid.Parse("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                    Name = "Madrid"
                },
                new City
                {
                    Id = Guid.Parse("e60c7b5e-b72b-4f85-a1c3-eadc8a9d89b3"),
                    IdCountry = Guid.Parse("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                    Name = "Paris"
                },
                new City
                {
                    Id = Guid.Parse("8c8c08d3-665c-40d5-a96a-44eb76e89bb1"),
                    IdCountry = Guid.Parse("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                    Name = "Lyon"
                },
                new City
                {
                    Id = Guid.Parse("fea6d774-33df-49d3-bc3f-e1c582a7dc0c"),
                    IdCountry = Guid.Parse("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                    Name = "Berlin"
                },
                new City
                {
                    Id = Guid.Parse("74e29a0c-7d0d-4b4b-b88a-1d68a7e7b028"),
                    IdCountry = Guid.Parse("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                    Name = "Munich"
                },
                new City
                {
                    Id = Guid.Parse("26c2a2da-7b14-4901-9447-19f5cfa42e15"),
                    IdCountry = Guid.Parse("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                    Name = "New York"
                },
                new City
                {
                    Id = Guid.Parse("aa3e69d9-b7e3-4b64-bc5e-6cb8c6f52a15"),
                    IdCountry = Guid.Parse("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                    Name = "Los Angeles"
                },
            };

            // Seed data for cities
            modelBuilder.Entity<City>().HasData(cities);
        }
    }
}
