using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class ManufacturersRepository : IManufacturersRepository
    {
        private readonly DbSet<Manufacturer> _manufacturer;

        public ManufacturersRepository(DbSet<Manufacturer> manufacturer)
        {
            _manufacturer = manufacturer;
        }
    }
}