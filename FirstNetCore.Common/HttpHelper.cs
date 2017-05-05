using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirstNetCore.Common
{
    /// <summary>
    /// http帮助类
    /// </summary>
    public class HttpHelper
    {
        private static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";

        /// <summary>
        /// 同步Post请求
        /// </summary>
        /// <param name="remoteUrl">url</param>
        /// <param name="postData">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encode">编码</param>
        /// <returns>结果</returns>
        public static string SyncPost(string remoteUrl, string postData = null, int timeOut = 30000, string encode = "UTF-8")
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                HttpContent hc = new StreamContent(ms);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
                hc.Headers.Add("UserAgent", UserAgent);
                hc.Headers.Add("Timeout", timeOut.ToString());
                hc.Headers.Add("KeepAlive", "true");
                var response = client.PostAsync(remoteUrl, hc);
                response.Wait();
                var t2 = response.Result.Content.ReadAsByteArrayAsync();
                result = Encoding.GetEncoding(encode).GetString(t2.Result);
            }
            return result;
        }

        /// <summary>
        /// POST 异步
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="postData">参数</param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string postData = null, Encoding encoding = null, int timeOut = 10000)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                //formData.FillFormDataStream(ms);//填充formData
                HttpContent hc = new StreamContent(ms);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
                hc.Headers.Add("UserAgent", UserAgent);
                hc.Headers.Add("Timeout", timeOut.ToString());
                hc.Headers.Add("KeepAlive", "true");
                var r = await client.PostAsync(url, hc);
                byte[] tmp = await r.Content.ReadAsByteArrayAsync();
                result = encoding.GetString(tmp);
            }
            return result;
        }

        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, int timeOut = 10000, Encoding encoding = null)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(timeOut);
            var data = await httpClient.GetByteArrayAsync(url);
            var ret = encoding.GetString(data);
            return ret;
        }

        /// <summary>
        /// Http Get 同步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpGet(string url, int timeOut = 10000, Encoding encoding = null)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(timeOut);
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding.GetString(t.Result);
            return ret;
        }
    }
}
