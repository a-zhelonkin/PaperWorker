using System;
using System.Collections.Generic;
using Database.Models.Addressing;

namespace Database.Repositories
{
    public interface ILocalitiesRepository
    {
        Locality Get(Guid id);
        IEnumerable<Locality> GetByTerritoryId(Guid territoryId);
        void Add(Locality locality);
        bool Exists(Guid territoryId, string name);
    }
}