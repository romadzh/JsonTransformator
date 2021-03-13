using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.PL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Consist.JsonTransformator.PL.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// provide access only to authorized users
        /// </summary>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userAuthenticated = context.HttpContext.Items.ContainsKey("userAuthenticated") && 
                                    (bool)context.HttpContext.Items["userAuthenticated"];
            if (!userAuthenticated)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
