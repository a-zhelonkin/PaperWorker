using System.Data.Entity;
using Database.Models.Account;

namespace Database
{
    public class PaperWorkerDbContext : DbContext
    {
        public PaperWorkerDbContext() : base(nameof(PaperWorkerDbContext))
        {
        }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region User

            modelBuilder.Entity<User>()
                .HasMany(user => user.Roles)
                .WithMany(role => role.Users)
                .Map(config =>
                {
                    config.MapLeftKey("UserId");
                    config.MapRightKey("RoleId");
                    config.ToTable("UserRoles");
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}