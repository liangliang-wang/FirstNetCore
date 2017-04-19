using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCore.Web.Authorize
{
    public class Constant
    {
        /// <summary>
        /// !!!建议配置项写到统一配置或者配置文件中
        /// </summary>
        public static string ApplyTokenRedirectUri = "";//授权登录回调本系统地址
        /// <summary>
        /// 线下配置
        /// </summary>
        public static string StateApplyForCodeUri = "";//通过state申请code地址
        public static string CodeApplyForTokenUri = "";//通过code申请token地址
        public static string GetUserInfoByTokenUri = "";//获取用户信息地址
        public static string SSOLogoutUri = "";//SSO退出登录地址
       
        //客户端属性
        public const string Scope = "read";
        public const string ResponseType = "code";
        public static string ClientId = "";
        public static string ClientSecret = "";
        public const string GrantType = "";

        public const string AccessToken = "";
        public const string UserName = "";
        public const string Department = "";
        public static string WebRootPath = "/";//leader


        static Constant()
        {
           
        }
    }
}
