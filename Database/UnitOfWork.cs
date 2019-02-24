using System;
using Database.Repositories;

namespace Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaperWorkerDbContext _context;

        private IUserRepository _userRepository;
        private IRolesRepository _rolesRepository;
        private IProfilesRepository _profilesRepository;
        private IEmailMessagesRepository _emailMessagesRepository;

        public UnitOfWork(PaperWorkerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose() => _context.Dispose();

        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository(_context.Users);

        public IRolesRepository RolesRepository =>
            _rolesRepository = _rolesRepository ?? new RolesRepository(_context.Roles);

        public IProfilesRepository ProfilesRepository =>
            _profilesRepository = _profilesRepository ?? new ProfilesRepository(_context.Profiles);

        public IEmailMessagesRepository EmailMessagesRepository =>
            _emailMessagesRepository = _emailMessagesRepository ?? new EmailMessagesRepository(_context.EmailMessages);

        public void Save() => _context.SaveChanges();
    }
}