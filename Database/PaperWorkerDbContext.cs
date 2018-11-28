using System.IO;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class PaperWorkerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString(nameof(PaperWorkerDbContext));

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            #region User
//
//            modelBuilder.Entity<User>()
//                .HasMany(user => user.Roles)
//                .WithMany(role => role.Users)
//                .Map(config =>
//                {
//                    config.MapLeftKey("UserId");
//                    config.MapRightKey("RoleId");
//                    config.ToTable("UserRoles");
//                });
//
//            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}