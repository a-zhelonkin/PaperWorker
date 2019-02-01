using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class ControllerBaseExtension
    {
        public static string GetEmail(this ControllerBase controller)
        {
            return controller.HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
        }
    }
}