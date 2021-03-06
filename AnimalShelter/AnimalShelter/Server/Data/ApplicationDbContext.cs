using AnimalShelter.Server.Models;
using AnimalShelter.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 1,
                        Name = "Max",
                        AnimalKind = AnimalKind.Dog,
                        EstimatedAge = 1,
                        PictureUrl = "https://cdn.pixabay.com/photo/2017/06/24/09/13/dog-2437110__340.jpg",
                        Gender = Gender.Male
                    });

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 2,
                        Name = "Kitty",
                        AnimalKind = AnimalKind.Cat,
                        DateOfBirth = new DateTime(2018, 01, 30),
                        PictureUrl = "https://cdn.pixabay.com/photo/2014/04/13/20/49/cat-323262__340.jpg",
                        Gender = Gender.Female
                    });

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 3,
                        Name = "Lucy",
                        AnimalKind = AnimalKind.Dog,
                        EstimatedAge = 2,
                        PictureUrl = "https://cdn.pixabay.com/photo/2018/03/18/18/06/australian-shepherd-3237735__340.jpg",
                        Gender = Gender.Female
                    });

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 4,
                        Name = "Charlie",
                        AnimalKind = AnimalKind.Dog,
                        EstimatedAge = 3,
                        PictureUrl = "https://cdn.pixabay.com/photo/2017/10/02/21/56/dog-2810484__340.jpg",
                        Gender = Gender.Male
                    });

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 5,
                        Name = "Simba",
                        AnimalKind = AnimalKind.Cat,
                        EstimatedAge = 1,
                        PictureUrl = "https://cdn.pixabay.com/photo/2017/11/09/21/41/cat-2934720__340.jpg",
                        Gender = Gender.Female
                    });

            builder.Entity<Animal>().HasData(
                    new Animal
                    {
                        Id = 6,
                        Name = "Sammy",
                        AnimalKind = AnimalKind.Cat,
                        EstimatedAge = 6,
                        PictureUrl = "https://cdn.pixabay.com/photo/2017/03/14/14/49/cat-2143332__340.jpg",
                        Gender = Gender.Male
                    });

            builder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "DogFood",
                        Price = 10.99m,
                        VatPercentage = 21,
                        ProductImageUrl = "https://avatars.mds.yandex.net/get-mpic/1911047/img_id1348695894112523125.jpeg/orig"
                    });
        }
    }
}
