using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class ConsumersRepository : IConsumersRepository
    {
        private readonly DbSet<Consumer> _consumers;

        public ConsumersRepository(DbSet<Consumer> consumers)
        {
            _consumers = consumers;
        }
    }
}