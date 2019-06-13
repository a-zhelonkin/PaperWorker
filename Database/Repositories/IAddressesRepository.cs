using System;
using System.Collections.Generic;
using Database.Models.Addressing;

namespace Database.Repositories
{
    public interface IAddressesRepository
    {
        Address Get(Guid id);
        IEnumerable<Address> GetByStructureId(Guid structureId);
        void Add(Address address);
        bool Exists(Guid structureId, int number);
    }
}