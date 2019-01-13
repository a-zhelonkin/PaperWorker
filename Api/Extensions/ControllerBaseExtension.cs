using System.Security.Claims;
using Database;
using Database.Extensions;
using Database.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class ControllerBaseExtension
    {
        public static string GetEmail(this ControllerBase controller)
        {
            return controller.HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
        }

        public static User GetUser(this ControllerBase controller, PaperWorkerDbContext context)
        {
            var email = controller.GetEmail();
            return email == null ? null : context.GetUser(email);
        }
    }
}