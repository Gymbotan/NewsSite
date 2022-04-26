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
    /// <summary>
    /// AppDbContext class for connection to DataBase using Entity Framework.
    /// </summary>
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContext Options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        /// <summary>
        /// Table for TextFields.
        /// </summary>
        public DbSet<TextField> TextFields { get; set; }

        /// <summary>
        /// Table for Articles.
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// DataBase creating.
        /// </summary>
        /// <param name="builder">Model Builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c96286ab-394c-45d2-a16b-8a19e1523ed0",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
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

            builder.Entity<IdentityUserRole<string>>().HasData(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
            {
                RoleId = "c96286ab-394c-45d2-a16b-8a19e1523ed0",
                UserId = "a7ba3363-2d50-4bf4-ba61-6b7161d429c8"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("f979c12f-2c29-4f85-8dc6-2e08b7220ed4"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("641dadbe-b8e8-4904-a73d-6ead038b2722"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("d340fdc7-2758-4e61-acb3-66c30c67273f"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
