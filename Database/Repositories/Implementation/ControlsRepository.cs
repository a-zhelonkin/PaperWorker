using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class ControlsRepository : IControlsRepository
    {
        private readonly DbSet<Control> _controls;

        public ControlsRepository(DbSet<Control> controls)
        {
            _controls = controls;
        }
    }
}