using Database;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    public class DbController : Controller
    {
        protected readonly IUnitOfWork UnitOfWork;

        public DbController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}