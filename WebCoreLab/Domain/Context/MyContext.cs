using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebCoreLab.Domain.Context
{
    public class MyContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Festival> Festivals { get; set; }
        public DbSet<Artist> Artists { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(x => x.Users);

            modelBuilder.Entity<Artist>().ToTable("Artist");

            //Database.SetInitializer<StoreContext>(null);
            //base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
