using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly DbSet<Address> _addresses;

        public AddressesRepository(DbSet<Address> addresses) => _addresses = addresses;

        public IEnumerable<Address> GetByStructureId(Guid structureId) => _addresses.Where(address => address.StructureId == structureId);

        public void Add(Address address) => _addresses.Add(address);

        public bool Exists(Guid structureId, int number) => _addresses.Any(address => address.StructureId == structureId && address.Number == number);
    }
}