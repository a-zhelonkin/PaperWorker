using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class StructuresRepository : IStructuresRepository
    {
        private readonly DbSet<Structure> _structures;

        public StructuresRepository(DbSet<Structure> structures)
        {
            _structures = structures;
        }
    }
}