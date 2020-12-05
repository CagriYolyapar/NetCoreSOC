using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Services.Abstracts;
using Project.BLL.Services.Concretes;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.BLL.ServiceExtensions;
using Autofac.Extensions.DependencyInjection;



namespace Project.BLL.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //https://stackoverflow.com/questions/50125132/autofac-net-core-register-dbcontext //=>ToDO: burası cok önemli buradaki DbContext registration'a bir bak!!!

            //services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            //services.AddTransient(typeof(IManager<>), typeof(BaseManager<>));
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IProductManager, ProductManager>();

            IServiceCollection ni = new ServiceCollection();
            
            ni.AddIdentity<IdentityUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();

            builder.Populate(ni);
           


            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IManager<>));
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserManagerSpecial>().As<IUserManagerSpecial>();
            #region NotWorking
            //builder.RegisterType<UserManager<IdentityUser, IdentityRole>>().As<UserManager<IUser, Guid>>().InstancePerRequest();
            //builder.RegisterType<UserManager<IdentityUser,Guid>>().AsSelf().InstancePerLifetimeScope();


            //builder.RegisterType<UserManager<IUser,string>>().AsSelf(); 
            #endregion



            builder.Register(c =>
            {
                
                var config = c.Resolve<IConfiguration>();
                
                var opt = new DbContextOptionsBuilder<MyContext>();
                
                opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection").Value).UseLazyLoadingProxies();//aman diyeyim buradaki GetSection'a dikkat et yanlıs string argüman verme... https://stackoverflow.com/questions/50125132/autofac-net-core-register-dbcontext burası cok önemli cok
              


                return new MyContext(opt.Options);


            }).AsSelf().InstancePerLifetimeScope();//AsSelf'e önem ver!!Yoksa yine For the different patterns supported at design time hatası alırsın InstancePerDependency()'ye önem ver yoksa aynı anda aynı Context'e erişilmeye calısılıyor... Ama await'i yazmazsan oluyor sanırım bu arastır!! Evet concurrent olayından dolayı oluyormus.. O yüzden async metotlarda await yazmaya dikkat et yoksa o metot tamamlanmadan aynı anda baska bir görev yine aynı context'e gider(multiple threading olayı) ve hata alırsın sayfada...


          
        }
    }
}
