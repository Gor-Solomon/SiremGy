using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiremGy.DAL.EF
{
    public class SiremGyDbContext : DbContext
    {
        public SiremGyDbContext(DbContextOptions<SiremGyDbContext> dbContextOptions) : base(dbContextOptions)
        {
           // DataSeeder.Initialize(this);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<UserEntity>().HasIndex(i => i.Email).IsUnique();
        //}

        public DbSet<UserEntity> Users { get; set; }
    }
}
