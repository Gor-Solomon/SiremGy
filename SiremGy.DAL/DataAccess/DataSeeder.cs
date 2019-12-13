using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiremGy.DAL.DataAccess
{
    public class DataSeeder
    {
        public static void Initialize(SiremGyDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var users = new List<UserModel>()
                {
                  new UserModel { /*Id = 1,*/ UserName = "John", Email = "john@john.com" },
                  new UserModel { /*Id = 2,*/ UserName = "Michael", Email = "michael@michael.com" }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }

        }
    }
}
