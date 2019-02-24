using System;
using System.Linq;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly DbSet<Profile> _profiles;

        public ProfilesRepository(DbSet<Profile> profiles)
        {
            _profiles = profiles;
        }

        public Profile Get(Guid userId)
        {
            return _profiles.FirstOrDefault(profile => profile.UserId == userId);
        }

        public void Update(Profile profile)
        {
            _profiles.Update(profile);
        }
    }
}