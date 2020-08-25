using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confString;
        public Startup(IHostEnvironment hostenv)
        {
            _confString = new ConfigurationBuilder()
            .SetBasePath(hostenv.ContentRootPath)
            .AddJsonFile("dbsettings.json").Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionstring = _confString.GetConnectionString("DefaultConnectionString");
            // get connection string "DefaultConnectionString"  from dbsettings.json
            services.AddDbContext<AppDBContext>(options =>
                 options.UseSqlServer(connectionstring));

            services.AddTransient<IOrders, OrderRepository>();

            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc().AddMvcOptions(ab => ab.EnableEndpointRouting = false);
            /* services.AddTransient<IAllCars, MockCars>();
            services.AddTransient<ICarsCategory, MockCategory>();*/
            MvcOptions compatibilities = new MvcOptions();
            compatibilities.EnableEndpointRouting = false;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "categoryFilter", 
                    template: "Cars/{action}/{category?}",
                    defaults:new { controller = "Cars", action = "List" });
            });
            //return;
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            using (var scoope = app.ApplicationServices.CreateScope())
            {
                AppDBContext content = scoope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(content);
            }
            /* return;
             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
             if (env.IsProduction())
             {
                 app.Run(async context =>
                 {
                     await context.Response.WriteAsync("Production!");
                 });
             }
             app.UseRouting();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 });
             });*/
        }
    }
}
