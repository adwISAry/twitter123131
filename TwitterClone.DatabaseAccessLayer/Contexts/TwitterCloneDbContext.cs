using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities;
using TwitterClone.Core.Entities.Common;
using TwitterClone.DatabaseAccessLayer.Configurations;

namespace TwitterClone.DatabaseAccessLayer.Contexts
{
    public class TwitterCloneDbContext : IdentityDbContext
    {
        public TwitterCloneDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Without "configurations" folder:
            /* modelBuilder.Entity<Topic>().Property(table => table.Name).IsRequired().HasMaxLength(32);
            modelBuilder.Entity<Topic>().Property(table => table.CreateDate).HasDefaultValue(DateTime.Now); */

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Another variant:
            /* modelBuilder.ApplyConfigurationsFromAssembly(typeof(TopicConfiguration).Assembly); */

            modelBuilder.Entity<IdentityUser>()
                .Ignore(b => b.PhoneNumber)
                .Ignore(b => b.PhoneNumberConfirmed);
            
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added) 
                    entry.Entity.CreateDate = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
