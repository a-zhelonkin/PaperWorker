using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class MaintenancesRepossitory : IMaintenancesRepossitory
    {
        private readonly DbSet<Maintenance> _maintenances;

        public MaintenancesRepossitory(DbSet<Maintenance> maintenances)
        {
            _maintenances = maintenances;
        }
    }
}