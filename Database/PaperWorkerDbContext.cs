using System;
using System.Linq;
using Core;
using Database.Models;
using Database.Models.Account;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Database
{
    /// <summary>
    /// dotnet ef migrations add (comment)
    /// dotnet ef database update [(comment)]
    /// </summary>
    public class PaperWorkerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = new ConfigurationBuilder()
                                   .AddJsonFile("db.settings.json")
                                   .Build()
                                   .GetConnectionString(nameof(PaperWorkerDbContext));

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var godId = Guid.Parse("67af6f37-55b6-4a84-a87e-d059416e0af6");
            var godRoles = new[]
            {
                new Role {Id = RoleNameExtension.ConsumerRoleId, Name = RoleName.Consumer},
                new Role {Id = RoleNameExtension.LocksmithRoleId, Name = RoleName.Locksmith},
                new Role {Id = RoleNameExtension.AdminRoleId, Name = RoleName.Admin}
            };

            var roleNameConverter = new EnumToStringConverter<RoleName>();
            var userStatusConverter = new EnumToStringConverter<UserStatus>();
            var territoryTypeConverter = new EnumToStringConverter<TerritoryType>();

            #region User

            modelBuilder.Entity<User>()
                        .HasOne(profile => profile.Profile)
                        .WithOne()
                        .HasForeignKey<User>(user => user.Id);

            modelBuilder.Entity<User>()
                        .Property(user => user.Status)
                        .HasConversion(userStatusConverter);

            modelBuilder.Entity<User>()
                        .HasData(new User
                        {
                            Id = godId,
                            ProfileId = godId,
                            Email = "Zhelonkin.ru@yandex.ru",
                            Password = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
                            Status = UserStatus.Confirmed
                        });

            #endregion

            #region Role

            modelBuilder.Entity<Role>()
                        .Property(role => role.Name)
                        .HasConversion(roleNameConverter);

            modelBuilder.Entity<Role>().HasData(godRoles);

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
                        .HasForeignKey(userRole => userRole.RoleId);

            modelBuilder.Entity<UserRole>()
                        .HasData(godRoles.Select(role => new UserRole {UserId = godId, RoleId = role.Id}).ToArray());

            #endregion

            #region Consumer

            modelBuilder.Entity<Consumer>()
                        .HasOne(profile => profile.Profile)
                        .WithOne()
                        .HasForeignKey<Consumer>(consumer => consumer.Id);

            modelBuilder.Entity<Consumer>()
                        .HasOne(consumer => consumer.Address)
                        .WithMany(profile => profile.Consumers);

            #endregion

            #region Profile

            modelBuilder.Entity<Profile>()
                        .HasData(new Profile
                        {
                            Id = godId,
                            FirstName = "Саня",
                            LastName = "Желонкин",
                            Patronymic = "Викторович",
                            PhoneNumber = "+7 927 298 32 49"
                        });

            #endregion

            #region Address

            modelBuilder.Entity<Address>()
                        .HasOne(address => address.Structure)
                        .WithMany(structure => structure.Addresses);

            #endregion

            #region Structure

            modelBuilder.Entity<Structure>()
                        .HasOne(structure => structure.Street)
                        .WithMany(structure => structure.Structures);

            #endregion

            #region Street

            modelBuilder.Entity<Street>()
                        .HasOne(street => street.Locality)
                        .WithMany(structure => structure.Streets);

            #endregion

            #region Locality

            modelBuilder.Entity<Locality>()
                        .HasOne(locality => locality.Territory)
                        .WithMany(structure => structure.Localities);

            #endregion

            #region Territory

            modelBuilder.Entity<Territory>()
                        .HasOne(territory => territory.Parent)
                        .WithMany(territory => territory.Children)
                        .HasForeignKey(territory => territory.ParentId);

            modelBuilder.Entity<Territory>()
                        .Property(territory => territory.Type)
                        .HasConversion(territoryTypeConverter);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}