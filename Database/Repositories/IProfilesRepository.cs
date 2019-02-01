using System;
using Database.Models;

namespace Database.Repositories
{
    public interface IProfilesRepository
    {
        Profile GetProfile(Guid userId);

        void UpdateProfile(Profile profileDto);
    }
}