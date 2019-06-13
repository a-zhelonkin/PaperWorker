using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class StructuresRepository : IStructuresRepository
    {
        private readonly DbSet<Structure> _structures;

        public StructuresRepository(DbSet<Structure> structures) => _structures = structures;

        public Structure Get(Guid id) => _structures.Find(id);

        public IEnumerable<Structure> GetByStreetId(Guid streetId) => _structures.Where(locality => locality.StreetId == streetId);

        public void Add(Structure structure) => _structures.Add(structure);

        public bool Exists(Guid streetId, int number) => _structures.Any(structure => structure.StreetId == streetId && structure.Number == number);
    }
}