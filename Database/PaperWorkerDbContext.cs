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
                .AddJsonFile("dbsettings.json")
                .Build()
                .GetConnectionString(nameof(PaperWorkerDbContext));

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Role

            modelBuilder
                .Entity<Role>()
                .Property(role => role.Name)
                .HasConversion<string>();

            #endregion

            #region UserRole

            modelBuilder.Entity<UserRole>()
                .HasKey(userRole => new {userRole.UserId, userRole.RoleId});

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.UserId);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}