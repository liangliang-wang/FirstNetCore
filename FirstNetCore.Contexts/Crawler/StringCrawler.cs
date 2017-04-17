using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstNetCore.Contexts.Crawler
{
    public class StringCrawler : ICrawler
    {
        /// <summary>
        /// 爬虫启动事件
        /// </summary>
        public event EventHandler<OnStartEventArgs> OnStart;

        /// <summary>
        /// 爬虫完成事件
        /// </summary>
        public event EventHandler<OnCompletedEventArgs> OnCompleted;

        /// <summary>
        /// 定义PhantomJS内核参数
        /// </summary>
        private PhantomJSOptions options;

        /// <summary>
        /// 定义Selenium驱动配置
        /// </summary>
        private PhantomJSDriverService service;

        /// <summary>
        /// 启动爬虫进程
        /// </summary>
        /// <param name="uri">uri</param>
        /// <returns>任务</returns>
        public async Task Start(Uri uri)
        {
            await Task.Run(() =>
            {
                if (OnStart != null) this.OnStart(this, new OnStartEventArgs(uri));
                //var driver = new PhantomJSDriver(service,options);//实例化PhantomJS的WebDriver
            });
        }
    }
}
