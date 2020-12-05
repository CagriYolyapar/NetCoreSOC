using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.BLL.DependencyResolvers;

namespace Project.CoreUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = WebHost.CreateDefaultBuilder(args)
            //   .ConfigureServices(services => services.AddAutofac())
            //   .UseStartup<Startup>()
            //   .Build();

            //host.Run();
        }

        //todo : addautofaci kaldırarak dene (.ConfigureServices(x => x.AddAutofac())), bu olmadan da calısıyor!!
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args).ConfigureServices(x=> x.AddAutofac()).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
           {

               builder.RegisterModule(new AutofacBusinessModule());

           })
                .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           });


        #region NotWorking
        //       public static IWebHost BuildWebHost(string[] args) =>
        //WebHost.CreateDefaultBuilder(args).UseServiceProviderFactory
        //    .UseStartup<Startup>().
        //    .Build(); 
        #endregion





        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
