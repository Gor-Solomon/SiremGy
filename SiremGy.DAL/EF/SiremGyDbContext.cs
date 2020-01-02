using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SiremGy.DAL.DataAccess.Users;
using SiremGy.DAL.Entities.Photos;
using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SiremGy.DAL.EF
{
    public class SiremGyDbContext : DbContext
    {
        public SiremGyDbContext(DbContextOptions<SiremGyDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public void Initialize()
        {
            DataSeeder dataSeeder = new DataSeeder();
            dataSeeder.Initialize(this);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserDetailEntity> UserDetails { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
    }
}
