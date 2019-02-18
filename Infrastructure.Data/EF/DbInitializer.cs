using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Identity;
using Core.Domain.Identity.AggregateRoot;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EF
{
    public static class DbInitializer
    {


        private static void CreateDb(AppDbContext dbContext)
        {
            //dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
        }
        
        public static void Seed(AppDbContext dbContext)
        {
            CreateDb(dbContext);

            
            if (!dbContext.Users.Any(a =>a.Id== Guid.Empty))
            {
                dbContext.Users.Add(new User()
                {
                    Id = Guid.Empty,
                    Mobile = "09127260933",
                    Email = "majid.boumipour@gmail.com",
                    Password = "1234",
                    FirstName = "majid",
                    LastName = "boumipour",
                    DisplayName = "admin",
                    CreateDate = DateTime.Now,

                });
 
            }

           
            dbContext.SaveChanges();
        }
    }
}
