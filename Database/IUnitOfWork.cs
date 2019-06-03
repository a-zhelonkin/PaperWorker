using System;
using Database.Repositories;

namespace Database
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        IProfilesRepository ProfilesRepository { get; }
        IEmailMessagesRepository EmailMessagesRepository { get; }
        IConsumersRepository ConsumersRepository { get; }
        IAddressesRepository AddressesRepository { get; }
        IStructuresRepository StructuresRepository { get; }
        IStreetsRepository StreetsRepository { get; }
        ILocalitiesRepository LocalitiesRepository { get; }
        ITerritoriesRepository TerritoriesRepository { get; }
    }
}