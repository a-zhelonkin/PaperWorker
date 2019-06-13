using System;
using System.Collections.Generic;
using Database.Models.Addressing;

namespace Database.Repositories
{
    public interface IStreetsRepository
    {
        Street Get(Guid id);
        IEnumerable<Street> GetByLocalityId(Guid localityId);
        void Add(Street street);
        bool Exists(Guid localityId, string name);
    }
}