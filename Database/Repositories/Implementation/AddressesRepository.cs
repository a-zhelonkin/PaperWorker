using Database.Models.Addressing;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly DbSet<Address> _addresses;

        public AddressesRepository(DbSet<Address> addresses)
        {
            _addresses = addresses;
        }
    }
}