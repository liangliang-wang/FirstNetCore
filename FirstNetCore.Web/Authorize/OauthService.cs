using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirstNetCore.Web.Authorize
{
    public class OauthService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns></returns>
        public static string GetUserInfo(string token)
        {
            var param = new NameValueCollection();
            param[Constant.AccessToken] = token;
            return PostRequest(Constant.GetUserInfoByTokenUri, param);
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static string PostRequest(string url, NameValueCollection param)
        {
            
            var webClient = new HttpWebRequest();
            webClient.
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = webClient.UploadValues(url, "POST", param);
            return Encoding.UTF8.GetString(responseData);
        }

        /// <summary>
        /// 生成授权登录登录地址
        /// </summary>
        /// <returns></returns>
        public static string GenerateLoginUrl(string returnUri)
        {
            // 用于防止跨站请求伪造（CSRF）攻击
            var state = Guid.NewGuid().ToString().Replace("-", "");
            var cookie = new HttpCookie("state", state)
            {
                Path = Constant.WebRootPath
            };
            HttpContext.Current.Response.AppendCookie(cookie);
            var fullUri = new StringBuilder();
            fullUri.Append(Constant.StateApplyForCodeUri)
                .Append("?response_type=").Append(Constant.ResponseType)
                .Append("&scope=").Append(Constant.Scope)
                .Append("&client_id=").Append(Constant.ClientId)
                .Append("&redirect_uri=").Append(HttpUtility.UrlEncode(Constant.ApplyTokenRedirectUri, Encoding.UTF8))
                .Append("&state=").Append(state)
                .Append("&return_uri=").Append(System.Web.HttpUtility.UrlEncode(returnUri, Encoding.UTF8));
            return fullUri.ToString();
        }
    }
}
