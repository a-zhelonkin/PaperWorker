using Api.Extensions;
using Api.Models.Account;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var email = this.GetEmail();
            if (email == null)
            {
                return View(new AuthInfoDto());
            }

            var user = _unitOfWork.UserRepository.GetWithRoles(email);
            if (user == null)
            {
                return View(new AuthInfoDto());
            }

            return View(new AuthInfoDto
            {
                Email = email,
                Roles = user.GetRoleNames()
            });
        }
    }
}