using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Moke;
using Microsoft.Extensions.Configuration;
using ProjectTest.Data;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data.Repository;
using ProjectTest.Data.Model;

namespace ProjectTest
{
    public class Startup
    {

        IConfiguration _configurationRoot;

        public Startup(IHostingEnvironment hostingEnviroment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnviroment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDrink, DrinkRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IShopingCart, ShopingCartRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopingCard.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(route =>
            {
                route.MapRoute(name: "categoryFilter", template: "Drink/{action}/{category?}", defaults: new { Controller = "Drink", action = "List" });
                route.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            });
        }

        //DbInitializer.seed(app);
    }
}

                ;
