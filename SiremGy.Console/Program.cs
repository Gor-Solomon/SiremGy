using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using SiremGy.DAL;
using SiremGy.DAL.EF;
using SiremGy.DAL.Entities.Photos;

namespace SiremGy.ConsolePanel
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = GetDbContext();
            
            var user = context.Users.Add(new DAL.Entities.Users.UserEntity()
            {
                UniqueID = Guid.NewGuid(),
                Email = Guid.NewGuid().ToString(),
                UserName = "AHMAd",
                MobileNumber = "44447342",
                PasswordHash = new byte[] { 1, 1, 3, 5 },
                PasswordSalt = new byte[] { 1, 1, 3, 5 },
                CreationDate = DateTime.Now,
                LastActive = DateTime.Now,
                UserDetail = new DAL.Entities.Users.UserDetailEntity()
                {
                    Address = "dawdawd",
                    Country = "Syria",
                    Birthday = DateTime.Now, 
                }
            }).Entity;

            context.SaveChanges();

            var photo = context.Photos.Add(new DAL.Entities.Photos.PhotoEntity()
            {
                DateAdded = DateTime.Now,
                Url = "dawdawdawd2",
                Description = "dawdaw2",
                Visible = false,
                UserDetailId = user.UserDetail.Id,
                UserDetail = user.UserDetail
            }).Entity;

            context.SaveChanges();

            user.UserDetail.Photo = photo;
            context.SaveChanges();

            user.UserDetail.Photos = new List<PhotoEntity>();



            for (int i = 0; i < 5; i++)
            {
                var photoTemp = context.Photos.Add(new DAL.Entities.Photos.PhotoEntity()
                {
                    DateAdded = DateTime.Now,
                    Url = i.ToString(),
                    Description = "dawdaw2",
                    Visible = false, 
                    UserDetailId = user.UserDetail.Id
                }).Entity;


                user.UserDetail.Photos.Add(photoTemp);
            }

            context.SaveChanges();
            context.Dispose();
        }

        private static SiremGyDbContext GetDbContext()
        {
            DbContextOptionsBuilder<SiremGyDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SiremGyDbContext>();
            dbContextOptionsBuilder.UseSqlite("Data Source=../../../../SiremGy.db");
            var x = new SiremGyDbContext(dbContextOptionsBuilder.Options);
            x.Database.EnsureDeleted();
            x.Database.Migrate();
            return x;
        }
    }
}
