using System;
using System.Linq;
using Database.Models;

namespace Database.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly PaperWorkerDbContext _context;

        public ProfilesRepository(PaperWorkerDbContext context)
        {
            _context = context;
        }

        public Profile GetProfile(Guid userId)
        {
            return _context.Profiles.FirstOrDefault(profile => profile.UserId == userId);
        }

        public void UpdateProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
        }
    }
}