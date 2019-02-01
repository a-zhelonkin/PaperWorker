using System;
using Database.Repositories;

namespace Database
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        IProfilesRepository ProfilesRepository { get; }

        void Save();
    }
}