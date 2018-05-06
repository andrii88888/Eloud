using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCoreLab.Models;
using WebCoreLab.Domain;

namespace WebCoreLab.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Festival> Festivals { get; set; }
        public DbSet<Artist> Artists { get; set; }
<<<<<<< HEAD
        public DbSet<ViewUserEvent> ViewUserEvent { get; set; }
=======
        public DbSet<Subscribtion> Subscribers { get; set; }
>>>>>>> Added Filtering & Subscribtion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);       
        }
    }
}
