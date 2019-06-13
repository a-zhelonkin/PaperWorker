using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class StreetsRepository : IStreetsRepository
    {
        private readonly DbSet<Street> _streets;

        public StreetsRepository(DbSet<Street> streets) => _streets = streets;

        public Street Get(Guid id) => _streets
                                      .Where(street => street.Id == id)
                                      .Include(street => street.Structures)
                                      .SingleOrDefault();

        public IEnumerable<Street> GetByLocalityId(Guid localityId) => _streets.Where(locality => locality.LocalityId == localityId);

        public void Add(Street street) => _streets.Add(street);

        public bool Exists(Guid localityId, string name) => _streets.Any(street => street.LocalityId == localityId && street.Name == name);
    }
}