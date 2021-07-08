using System.Linq;
using Microsoft.AspNetCore.Http;

namespace App.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidarUserClaims(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated && context.User.Claims.Any(c =>
                c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}