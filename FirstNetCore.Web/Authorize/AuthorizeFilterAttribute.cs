using FirstNetCore.Web.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FirstNetCore.Web
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public AuthorizeFilterAttribute()
        {
            Roles = Roles ?? string.Empty;
        }
        public virtual void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (string.IsNullOrWhiteSpace(Roles))
            {
                return;
            }
            List<string> roles = Roles.Split(',').ToList();
            IIdentity identity = filterContext.HttpContext.User.Identity;
            if (roles.Contains(AuthorizationHelper.PublicRole))
            {
                return;
            }
            var token = filterContext.HttpContext.Request.Cookies[Constant.AccessToken];
            if (token != null && !string.IsNullOrEmpty(token))
            {
                return;
            }
            //var returnUri = filterContext.HttpContext.Request.;
           // filterContext.HttpContext.Response.Redirect("/Account/Login");
            filterContext.HttpContext.Response.Redirect("/Home/AuthPage");
            return;
            //filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
