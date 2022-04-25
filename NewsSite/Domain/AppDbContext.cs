using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<TextField> TextFields { get; set; }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c96286ab-394c-45d2-a16b-8a19e1523ed0",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "a7ba3363-2d50-4bf4-ba61-6b7161d429c8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
            {
                RoleId = "c96286ab-394c-45d2-a16b-8a19e1523ed0",
                UserId = "a7ba3363-2d50-4bf4-ba61-6b7161d429c8"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("f979c12f-2c29-4f85-8dc6-2e08b7220ed4"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("641dadbe-b8e8-4904-a73d-6ead038b2722"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("d340fdc7-2758-4e61-acb3-66c30c67273f"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
