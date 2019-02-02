using System;
using Database.Models;

namespace Database.Repositories
{
    public interface IProfilesRepository
    {
        Profile Get(Guid userId);

        void Update(Profile profileDto);
    }
}