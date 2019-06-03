using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class TerritoriesRepository : ITerritoriesRepository
    {
        private readonly DbSet<Territory> _territories;

        public TerritoriesRepository(DbSet<Territory> territories)
        {
            _territories = territories;
        }
    }
}