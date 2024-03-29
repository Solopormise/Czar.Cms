﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample01
{
    public class Program
    {
        /// <summary>
        /// Main 方法 程序的入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)// 调用下面的方法 返回一个IWebHostBuilder 对象
                .Build()// 用上面返回的IWebHostBuilder 对象创建一个IWebHost
                .Run();//运行上面创建的IWebHost对象从而运行我们的Web应用程序换句话说就是启动一个一直运行监听http请求的任务
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // 使用默认的配置信息来初始化一个新的IWebHostBuilder实例
            .ConfigureAppConfiguration((hostingContext, config) => {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName }.json", optional: true, reloadOnChange: true)
                .AddJsonFile("Content.json", optional: false, reloadOnChange: false)// 传统的asp.net 的web.config 文件如果有更新的话，是需要重启站点才能使配置文件生效的，但是 aps.net core
                //的配置文件是支持热更新的，即使不重启站点也能加载更新，只需要 设置 reloadOnChange 属性为true.
                .AddEnvironmentVariables();
            })
                .UseStartup<Startup>();// 为Web Host指定了Startup类
    }
}
