using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OmanAirportsApp.API.Data
{
    public partial class omanairportdbContext : IdentityDbContext<ApiUser>
    {
        public omanairportdbContext()
        {
        }
        public omanairportdbContext(DbContextOptions<omanairportdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(60);

                entity.Property(e => e.LastName).HasMaxLength(60);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Isbn).HasMaxLength(20);

                entity.Property(e => e.Summary).HasMaxLength(60);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);
            });

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Name = "User",
                   NormalizedName = "USER",
                   Id = "8343074e-8623-4e1a-b0c1-84fb8678c8f3"
               },
               new IdentityRole
               {
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",
                   Id = "c7ac6cfe-1f10-4baf-b604-cde350db9554"
               }
           );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "8e448afa-f008-446e-a52f-13c449803c2e",
                    Email = "admin@omanairports.com",
                    NormalizedEmail = "ADMIN@OMANAIRPORTS.COM",
                    UserName = "admin@omanairports.com",
                    NormalizedUserName = "ADMIN@OMANAIRPORTS.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new ApiUser
                {
                    Id = "30a24107-d279-4e37-96fd-01af5b38cb27",
                    Email = "user@omanairports.com",
                    NormalizedEmail = "USER@OMANAIRPORTS.COM",
                    UserName = "user@omanairports.com",
                    NormalizedUserName = "USER@OMANAIRPORTS.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                   UserId = "30a24107-d279-4e37-96fd-01af5b38cb27"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                   UserId = "8e448afa-f008-446e-a52f-13c449803c2e"
               }
           );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
