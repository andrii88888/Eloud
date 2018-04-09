using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            Role role = new Role()
            {
                Name = "Administrator",
                Code = "ADMIN"
            };


            User user = new User()
            {
                Email = "admin",
                Password = "1111",
                Role = role
            };

            role.Users.Add(user);
            context.Roles.Add(role);

            context.SaveChanges();

            var users = context.Users.ToList();
        }
    }
}

