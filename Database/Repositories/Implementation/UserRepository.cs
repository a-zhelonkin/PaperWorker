using System.Collections.Generic;
using System.Linq;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(DbSet<User> users)
        {
            _users = users;
        }

        public IEnumerable<User> Get()
        {
            return _users;
        }

        public IEnumerable<User> Get(int start, int size)
        {
            return _users.Skip(start)
                         .Take(size)
                         .Include(x => x.Profile)
                         .Include(x => x.Roles)
                         .ThenInclude(x => x.Role);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            _users.Update(user);
        }

        public User Get(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }

        public User GetWithRoles(string email)
        {
            return _users.Include(x => x.Roles)
                         .ThenInclude(x => x.Role)
                         .SingleOrDefault(x => x.Email == email);
        }
    }
}