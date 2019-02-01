using Core;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = nameof(RoleName.Admin))]
    [Route("api/roles")]
    [ApiController]
    public class RolesController : DbController
    {
        public RolesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}