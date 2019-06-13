using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class LocalitiesRepository : ILocalitiesRepository
    {
        private readonly DbSet<Locality> _localities;

        public LocalitiesRepository(DbSet<Locality> localities) => _localities = localities;

        public Locality Get(Guid id) => _localities
                                        .Where(locality => locality.Id == id)
                                        .Include(locality => locality.Streets)
                                        .SingleOrDefault();

        public IEnumerable<Locality> GetByTerritoryId(Guid territoryId) => _localities.Where(locality => locality.TerritoryId == territoryId);

        public void Add(Locality locality) => _localities.Add(locality);

        public bool Exists(Guid territoryId, string name) => _localities.Any(locality => locality.TerritoryId == territoryId && locality.Name == name);
    }
}