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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Profile Get(Guid userId)
        {
            return _context.Profiles.FirstOrDefault(profile => profile.UserId == userId);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }
    }
}