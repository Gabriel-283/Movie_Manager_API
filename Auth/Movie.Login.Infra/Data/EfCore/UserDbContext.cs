using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movie.Login.API.Models;

namespace Movie.Login.API.Data.EfCore
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 9999,
            };

            builder.Entity<IdentityRole<int>>().Property(o => o.Id).HasMaxLength(200);
            builder.Entity<IdentityRole<int>>().Property(o => o.Name).HasMaxLength(200);
            builder.Entity<IdentityRole<int>>().Property(o => o.NormalizedName).HasMaxLength(200);
            builder.Entity<IdentityRole<int>>().Property(o => o.ConcurrencyStamp).HasMaxLength(200);

            builder.Entity<CustomIdentityUser>().Property(o => o.Id).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.UserName).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.NormalizedUserName).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.Email).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.NormalizedEmail).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.PasswordHash).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.SecurityStamp).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.ConcurrencyStamp).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.PhoneNumber).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.PhoneNumberConfirmed).HasMaxLength(200);
            builder.Entity<CustomIdentityUser>().Property(o => o.EmailConfirmed).HasMaxLength(200);

            builder.Entity<IdentityUserRole<int>>().Property(o => o.UserId).HasMaxLength(200);

            Console.WriteLine(_configuration.GetValue<string>("adminInfo:password"));

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 9999 });
        }
    }
}
