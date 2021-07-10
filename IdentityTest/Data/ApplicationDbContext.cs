using System;
using System.Collections.Generic;
using System.Text;
using IdentityTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<DisplayCities> DisplayCities { get; set; }
        public DbSet<DisplayCountries> DisplayCountries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<Cities>().HasOne<ApplicationUser>(c => c.ApplicationUser)
                .WithOne(a => a.City).HasForeignKey<ApplicationUser>(a => a.CityId);

            builder.Entity<Countries>().HasKey(c => c.CountryId);
            builder.Entity<Cities>().HasKey(c => c.CityId);
            builder.Entity<Cities>()
                .HasOne(z => z.Country).WithMany(z => z.Cities).HasForeignKey(z => z.CountryId);

            builder.Entity<DisplayCities>().HasData
                (
                    new DisplayCities { Id = 1, Name = "Stockholm"},
                    new DisplayCities { Id = 2, Name = "Göteborg"},
                    new DisplayCities { Id = 3, Name = "London"},
                    new DisplayCities { Id = 4, Name = "Bergen"},
                    new DisplayCities { Id = 5, Name = "Floda"},
                    new DisplayCities { Id = 6, Name = "New York"},
                    new DisplayCities { Id = 7, Name = "Trondheim"},
                    new DisplayCities { Id = 8, Name = "Liverpool"},
                    new DisplayCities { Id = 9, Name = "Oslo"},
                    new DisplayCities { Id = 10, Name = "Washington"}
                );
            builder.Entity<DisplayCountries>().HasData
                (
                    new DisplayCountries { Id = 1, Name = "Sweden"},
                    new DisplayCountries { Id = 2, Name = "England"},
                    new DisplayCountries { Id = 3, Name = "Norway"},
                    new DisplayCountries { Id = 4, Name = "USA"}
                );
        }
    }
}