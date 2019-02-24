using Api.Extensions;
using Front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexModel
            {
                Email = this.GetEmail() ?? "guest"
            });
        }
    }
}