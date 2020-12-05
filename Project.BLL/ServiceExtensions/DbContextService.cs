using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;



namespace Project.BLL.ServiceExtensions
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            #region ServisKatmanindanCifteProviderGonderme

            //https://stackoverflow.com/questions/38356990/connectionstring-from-appsettings-json-in-data-tier-with-entity-framework-core

            //üstteki linkte buldugum kod özellikle UI'dan bir service provider almaya hazır bir kodu gösteriyor (Accepted Answer of  Joe Audette


            //services.AddDbContextPool<MyContext>((serviceProvider,options) => options.UseSqlServer(connectionString).UseInternalServiceProvider(serviceProvider));

            //Asagıda da UI tarafından nasıl cagırmamız gerektigini gösteriyor
            //var connectionString = Configuration.GetConnectionString("EntityFrameworkConnectionString");
            //services.AddMyServiceDependencies(connectionString); 
            #endregion

            //Üsttekine ek olarak soyle bir durum daha var 
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
          
           
            
            return services;
        }
    }
}
