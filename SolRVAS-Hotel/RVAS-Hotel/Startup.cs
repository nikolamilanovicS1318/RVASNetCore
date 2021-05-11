using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVAS_Hotel.Data;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

                endpoints.MapRazorPages();

            });
        }
    }
}
