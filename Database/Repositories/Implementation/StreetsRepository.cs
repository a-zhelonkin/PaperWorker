using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class StreetsRepository : IStreetsRepository
    {
        private readonly DbSet<Street> _streets;

        public StreetsRepository(DbSet<Street> streets)
        {
            _streets = streets;
        }
    }
}