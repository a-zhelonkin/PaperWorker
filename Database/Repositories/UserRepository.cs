using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PaperWorkerDbContext _context;

        public UserRepository(PaperWorkerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public User Get(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public User GetWithRoles(string email)
        {
            return _context.Users
                           .Include(x => x.Roles)
                           .ThenInclude(x => x.Role)
                           .SingleOrDefault(x => x.Email == email);
        }
    }
}