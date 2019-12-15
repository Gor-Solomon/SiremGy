using Microsoft.EntityFrameworkCore;
using SiremGy.DAL.Entities.Users;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiremGy.DAL.EF
{
    public class DataSeeder
    {
        internal static void Initialize(SiremGyDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<UserEntity>()
                {
                  new UserEntity { /*Id = 1,*/ UserName = "John", Email = "john@john.com" },
                  new UserEntity { /*Id = 2,*/ UserName = "Michael", Email = "michael@michael.com" }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
