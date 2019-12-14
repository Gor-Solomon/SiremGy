using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SiremGy.Models.Users;
using SiremGy.Models.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiremGy.DAL.DataAccess
{
    public class SiremGyDbContext : DbContext
    {
        public SiremGyDbContext(DbContextOptions<SiremGyDbContext> dbContextOptions) : base(dbContextOptions)
        {
            DataSeeder.Initialize(this);
        }

        public DbSet<ValueModel> Values { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
