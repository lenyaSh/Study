using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop.Data.Interfaces;
using shop.Data.mocs;
using shop.Data;
using shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using shop.Data.Models;

namespace shop {
    public class Startup {
        public IConfiguration Configuration { get; }
        private IConfiguration _confString;

        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Configuration = configuration;
            _confString = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("DbSettings.json").Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDBContent>(options=>options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            //services.AddRazorPages();

            // интерфейс IAllCars реализуется в классe MockCars
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddControllersWithViews(mvcOtions => {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {



            app.UseSession();
            // выводит страницу с ошибкой
            app.UseDeveloperExceptionPage();

            //выводит код страницы (404 и др.)
            app.UseStatusCodePages();

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", Action = "List"});
            });

            using (var scope = app.ApplicationServices.CreateScope()) {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
