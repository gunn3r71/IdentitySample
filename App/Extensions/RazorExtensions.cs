using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarUserClaims(page.Context, claimName, claimValue);
        }

        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarUserClaims(page.Context, claimName, claimValue) ? "btn-danger" : "btn-secondary disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context,string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarUserClaims(context, claimName, claimValue) ? page : null;
        }
    }
}
