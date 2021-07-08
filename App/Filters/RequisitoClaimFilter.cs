﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Filters
{
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CustomAuthorization.ValidarUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
