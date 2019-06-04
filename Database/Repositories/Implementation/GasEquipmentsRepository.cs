using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class GasEquipmentsRepository : IGasEquipmentsRepository
    {
        private readonly DbSet<GasEquipment> _equipments;

        public GasEquipmentsRepository(DbSet<GasEquipment> equipments)
        {
            _equipments = equipments;
        }
    }
}