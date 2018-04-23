using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eloud.Models;
using Eloud.Domain;

namespace Eloud.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Festival> Festivals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUserRole>().HasKey((ApplicationUserRole r) => new { UserId = r.UserId, RoleId = r.RoleId });

            ////added these definitions
            //modelBuilder.Entity<ApplicationUser>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
            //modelBuilder.Entity<ApplicationRole>().HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);
        }
    }
}
