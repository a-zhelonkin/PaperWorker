using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class TerritoriesRepository : ITerritoriesRepository
    {
        private readonly DbSet<Territory> _territories;

        public TerritoriesRepository(DbSet<Territory> territories) => _territories = territories;

        public IEnumerable<Territory> Get() => _territories;

        public IEnumerable<Territory> GetByParentId(Guid parentId) => _territories.Where(locality => locality.ParentId == parentId);

        public void Add(Territory territory) => _territories.Add(territory);

        public bool Exists(Guid parentId, string name) => _territories.Any(territory => territory.ParentId == parentId && territory.Name == name);
    }
}