﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiremGy.DAL.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SiremGyDbContext>
    {
        public SiremGyDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../SiremGy.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<SiremGyDbContext>();
            builder.UseSqlite(configuration.GetConnectionString("DatabaseConnection"));
            return new SiremGyDbContext(builder.Options);
        }
    }
}
