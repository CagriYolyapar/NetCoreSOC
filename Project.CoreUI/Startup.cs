using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BLL.DependencyResolvers;
using Project.BLL.ServiceExtensions;


namespace Project.CoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // services.AddDbContextService(); //todo burayı silip tekrar cıkacak hatayı göster!!!
            //Todo:RepositoryServices configure edilmezse unabletoconfigure service'e benzeyen bir hata alıyorsun arastır!!!
            //   services.AddRepositoryService(); //=> burayı da Configure etmeyi unutma!!!
         
        }



        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //https://github.com/autofac/Examples/blob/master/src/AspNetCoreExample/Startup.cs //kod linki
        //    // Add any Autofac modules or registrations.
        //    // This is called AFTER ConfigureServices so things you
        //    // register here OVERRIDE things registered in ConfigureServices.
        //    //
        //    // You must have the call to AddAutofac in the Program.Main
        //    // method or this won't be called.
        //    builder.RegisterModule(new AutofacBusinessModule());
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Simulation}/{action=Index}/{id?}");
            });
        }
    }
}
