using Microsoft.EntityFrameworkCore;
using MODEL.Entities;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Initialazier
{
   public static class DataInitialazier
    {
        public static void Seed(ModelBuilder modelBuilder )
        {
            string password1 = BCrypt.Net.BCrypt.HashPassword("ahmet54");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() { ID = 1, UserName = "admin", Password = password1, Role = MODEL.Enums.Role.admin }                );
        }
    }
}
