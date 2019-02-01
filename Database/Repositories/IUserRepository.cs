using System.Collections.Generic;
using Database.Models.Account;

namespace Database.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        void Add(User user);
        void Update(User user);
        User Get(string email);
        User GetWithRoles(string email);
    }
}