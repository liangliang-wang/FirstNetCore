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
        //public static string ApplyTokenRedirectUri = "http://localhost:8080/oauth/authorizationcodecallback";//授权登录回调本系统地址
        public static string ApplyTokenRedirectUri = "http://10.101.42.38:8006/oauth/authorizationcodecallback";//授权登录回调本系统地址
        /// <summary>
        /// 线下配置
        /// </summary>
        public static string StateApplyForCodeUri = "http://tccommon.qas.17usoft.com/oauth/authorize";//通过state申请code地址
        public static string CodeApplyForTokenUri = "http://tccommon.qas.17usoft.com/oauth/token";//通过code申请token地址
        public static string GetUserInfoByTokenUri = "http://tccommon.qas.17usoft.com/oauth/rs/getuserinfo";//获取用户信息地址
        public static string SSOLogoutUri = "http://tccommon.qas.17usoft.com/oauth/logout";//SSO退出登录地址
        /// <summary>
        /// 线上配置
        /// </summary>
        //public const string StateApplyForCodeUri = "http://tccommon.17usoft.com/oauth/authorize";//通过state申请code地址
        //public const string CodeApplyForTokenUri = "http://tccommon.17usoft.com/oauth/token";//通过code申请token地址
        //public const string GetUserInfoByTokenUri = "http://tccommon.17usoft.com/oauth/rs/getuserinfo";//获取用户信息地址
        //public const string SSOLogoutUri = "http://tccommon.17usoft.com/oauth/logout";//SSO退出登录地址

        //客户端属性
        public const string Scope = "read";
        public const string ResponseType = "code";
        public static string ClientId = "iv.travel.leader.local";
        public static string ClientSecret = "fe892a66131534abf2835a23a2da9216";
        public const string GrantType = "authorization_code";

        public const string AccessToken = "access_token";
        public const string UserName = "username";
        public const string Department = "department";
        public static string WebRootPath = "/";//leader


        static Constant()
        {
           
        }
    }
}
