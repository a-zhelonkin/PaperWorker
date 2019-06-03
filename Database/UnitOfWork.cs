using System;
using Database.Repositories;
using Database.Repositories.Implementation;

namespace Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaperWorkerDbContext _context;

        private IUserRepository _userRepository;
        private IRolesRepository _rolesRepository;
        private IProfilesRepository _profilesRepository;
        private IEmailMessagesRepository _emailMessagesRepository;
        private IConsumersRepository _consumersRepository;
        private IAddressesRepository _addressesRepository;
        private IStructuresRepository _structuresRepository;
        private IStreetsRepository _streetsRepository;
        private ILocalitiesRepository _localitiesRepository;
        private ITerritoriesRepository _territoriesRepository;

        public UnitOfWork(PaperWorkerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();

        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository(_context.Users);

        public IRolesRepository RolesRepository =>
            _rolesRepository = _rolesRepository ?? new RolesRepository(_context.Roles);

        public IProfilesRepository ProfilesRepository =>
            _profilesRepository = _profilesRepository ?? new ProfilesRepository(_context.Profiles);

        public IEmailMessagesRepository EmailMessagesRepository =>
            _emailMessagesRepository = _emailMessagesRepository ?? new EmailMessagesRepository(_context.EmailMessages);

        public IConsumersRepository ConsumersRepository =>
            _consumersRepository = _consumersRepository ?? new ConsumersRepository(_context.Consumers);

        public IAddressesRepository AddressesRepository =>
            _addressesRepository = _addressesRepository ?? new AddressesRepository(_context.Addresses);

        public IStructuresRepository StructuresRepository =>
            _structuresRepository = _structuresRepository ?? new StructuresRepository(_context.Structures);

        public IStreetsRepository StreetsRepository =>
            _streetsRepository = _streetsRepository ?? new StreetsRepository(_context.Streets);

        public ILocalitiesRepository LocalitiesRepository =>
            _localitiesRepository = _localitiesRepository ?? new LocalitiesRepository(_context.Localities);

        public ITerritoriesRepository TerritoriesRepository =>
            _territoriesRepository = _territoriesRepository ?? new TerritoriesRepository(_context.Territories);
    }
}