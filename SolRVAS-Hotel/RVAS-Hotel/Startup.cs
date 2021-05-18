
using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVAS_Hotel.Data;
using RVAS_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RVAS_Hotel
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
           
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Konfiguracija MongoDB Identiteta; podešene opcije
            /* var mongoDbIdentityConfiguration = new MongoDbIdentityConfiguration
             {
                 MongoDbSettings = new MongoDbSettings
                 {
                     ConnectionString = Configuration["DatabaseSettings:ConnectionString"],
                     DatabaseName = Configuration["DatabaseSettings:DatabaseName"]
                 },
                 IdentityOptionsAction = options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequiredLength = 8;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = true;
                     options.Password.RequireLowercase = false;


                     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                     options.Lockout.MaxFailedAccessAttempts = 20;


                     options.User.RequireUniqueEmail = true;
                     options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_";
                 }
             };
            */

            services.AddDefaultIdentity<User>().AddMongoDbStores<User, ApplicationRole, Guid>(
                        Configuration["DatabaseSettings:ConnectionString"],
                        Configuration["DatabaseSettings:DatabaseName"]

                ).AddDefaultTokenProviders();
 
               
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                app.UseAuthentication();
                app.UseAuthorization();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
            
                // Default ruta, home page
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                // Register ruta
                endpoints.MapControllerRoute(
                name: "register",
                pattern: "/register",
                defaults: new { controller = "User", action = "Register" }
                );
               


                // Ruta za dodavanje soba
                endpoints.MapControllerRoute(
                name: "add-room",
                pattern: "/add_room",
                defaults: new { controller = "Room", action = "RoomAdd" }
                );

                // Ruta za listanje svih trenutnih soba
                endpoints.MapControllerRoute(
                name: "all-rooms",
                pattern: "/all_rooms",
                defaults: new { controller = "Room", action = "Index" }
                );

                // Ruta na kojoj se ažuriraju podaci sobe
                endpoints.MapControllerRoute(
                name: "update-room",
                pattern: "/update_room/{id?}",
                defaults: new { controller = "Room", action = "UpdateRoom" }
                );

                // Ruta na kojoj se prikazuje stranica za ažuriranje podataka sobe
                endpoints.MapControllerRoute(
                 name: "room-update",
                 pattern: "/edit_room/{id?}",
                 defaults: new { controller = "Room", action = "RoomEdit" }
                 );

                endpoints.MapControllerRoute(
                name: "room-delete",
                pattern: "/delete_room/{id?}",
                defaults: new { controller = "Room", action = "DeleteRoom" }
                );

                //Ruta za prikazivanje podataka pojedinacne sobe
                endpoints.MapControllerRoute(
                name: "api-show",
                pattern: "/api_show/{id?}",
                defaults: new { controller = "Room", action = "ApiDetails" }
                );

                //Login Ruta

                endpoints.MapControllerRoute(
               name: "login-page",
               pattern: "/login",
               defaults: new { controller = "User", action = "LoginPage" }
               );
                endpoints.MapControllerRoute(
             name: "login",
             pattern: "/login_page",
             defaults: new { controller = "User", action = "Login" }
             );

                endpoints.MapRazorPages();

            });
        }
    }
}
