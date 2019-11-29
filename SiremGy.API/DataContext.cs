using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiremGy.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Value> values { get; set; }
    }

    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
