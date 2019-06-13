using System;
using System.Collections.Generic;
using Database.Models.Addressing;

namespace Database.Repositories
{
    public interface ITerritoriesRepository
    {
        Territory Get(Guid id);
        IEnumerable<Territory> GetByParentId(Guid? parentId);
        void Add(Territory territory);
        bool Exists(Guid parentId, string name);
    }
}