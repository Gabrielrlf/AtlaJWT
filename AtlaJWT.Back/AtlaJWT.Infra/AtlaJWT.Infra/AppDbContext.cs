using AtlaJWT.Domain;
using AtlaJWT.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AtlaJWT.Infra
{
    public class AppDbContext : IdentityDbContext
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=Atlantico.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserRegistered>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserRegistered");
            });

            modelBuilder.Entity<UserInfo>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserInfo");
            });
        }
    }
}
