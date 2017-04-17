using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstNetCore.Contexts.Crawler
{
    public interface ICrawler
    {
        /// <summary>
        /// 开始事件
        /// </summary>
        event EventHandler<OnStartEventArgs> OnStart;

        /// <summary>
        /// 完成事件
        /// </summary>
        event EventHandler<OnCompletedEventArgs> OnCompleted;

        /// <summary>
        /// 启动爬虫进程
        /// </summary>
        /// <param name="uri">uri</param>
        /// <returns>任务</returns>
        Task Start(Uri uri);
    }
}
