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
    //public class AuthorizeFilterAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    //{
    //    public virtual async Task OnAuthorizationAsync(AuthorizationFilterContext filterContext)
    //    {
    //        List<string> roles = Roles.Split(',').ToList();
    //        IIdentity identity =  filterContext.HttpContext.User.Identity;
    //        if (roles.Contains(AuthorizationHelper.PublicRole))
    //        {
    //            return ;
    //        }
    //    }
    //}
}
