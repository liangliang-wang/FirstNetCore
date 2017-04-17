using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCore.Web
{
    public class AuthorizationHelper
    {
        /// <summary>需要配置菜单才可以访问</summary>
        public const string MenuRole = "0";
        /// <summary>公用,不需要登录即可访问,如登录页面</summary>
        public const string PublicRole = "1";
        /// <summary>要登录才可以访问</summary>
        public const string LoginRole = "2";
    }
}
