using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class LocalitiesRepository : ILocalitiesRepository
    {
        private readonly DbSet<Locality> _localities;

        public LocalitiesRepository(DbSet<Locality> localities)
        {
            _localities = localities;
        }
    }
}