using System.Linq;
using Api.Extensions;
using Database;
using Front.Models;
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
                return View(new HomeIndexModel());
            }

            var user = _unitOfWork.UserRepository.GetWithRoles(email);
            if (user == null)
            {
                return View(new HomeIndexModel());
            }

            return View(new HomeIndexModel
            {
                Email = email,
                Roles = user.Roles
                            .Select(x => x.Role.Name)
                            .ToArray()
            });
        }
    }
}