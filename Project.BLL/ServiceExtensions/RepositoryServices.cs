using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Services.Abstracts;
using Project.BLL.Services.Concretes;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            //services.AddTransient(typeof(IManager<>), typeof(BaseManager<>));
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IProductManager, ProductManager>();

           services.AddIdentity<IdentityUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();
            //builder.Populate(ni);

            return services;

        }

    }
}
