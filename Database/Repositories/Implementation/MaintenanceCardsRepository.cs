using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class MaintenanceCardsRepository : IMaintenanceCardsRepository
    {
        private readonly DbSet<MaintenanceCard> _maintenanceCards;

        public MaintenanceCardsRepository(DbSet<MaintenanceCard> maintenanceCards)
        {
            _maintenanceCards = maintenanceCards;
        }
    }
}