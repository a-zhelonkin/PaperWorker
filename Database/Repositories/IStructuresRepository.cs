using System;
using System.Collections.Generic;
using Database.Models.Addressing;

namespace Database.Repositories
{
    public interface IStructuresRepository
    {
        Structure Get(Guid id);
        IEnumerable<Structure> GetByStreetId(Guid streetId);
        void Add(Structure structure);
        bool Exists(Guid streetId, int number);
    }
}