using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SiremGy.DAL.DataAccess.Users;
using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.EF
{
    internal sealed class DataSeeder
    {
        internal async void Initialize(SiremGyDbContext context)
        {
            if (!context.Users.Any())
            {
                var textFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/UsersSeedData.json");
                var users = JsonConvert.DeserializeObject<List<UserEntity>>(textFile);

                foreach (var item in users)
                {
                    item.UniqueID = Guid.NewGuid();
                    item.CreationDate = DateTime.Now;
                    byte[] salt;
                    item.PasswordHash = createPasswordHash(item.CreationDate, "123456789", out salt);
                    item.PasswordSalt = salt;
                    item.Email = item.Email.ToLower();
                    var temp = item.UserDetail.Photo;
                    item.UserDetail.Photo = null;

                    context.Users.Add(item);
                    context.SaveChanges(true);

                    temp.UserDetailId = item.UserDetail.Id;
                    context.Photos.Add(temp);

                    context.SaveChanges(true);
                    item.UserDetail.Photo = temp;
                }

                context.SaveChanges(true);
            }
        }

        byte[] createPasswordHash(DateTime dateTime, string password, out byte[] passwordSalt)
        {
            byte[] result = null;
            byte[] dateArray = BitConverter.GetBytes(dateTime.Ticks);
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            byte[] input = new byte[dateArray.Length + passwordArray.Length];

            dateArray.CopyTo(input, 0);
            passwordArray.CopyTo(input, dateArray.Length);

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                result = hmac.ComputeHash(input);
                Array.Clear(input, 0, input.Length);
                Array.Clear(passwordArray, 0, passwordArray.Length);
                GC.Collect();
            }

            return result;
        }
    }
}
