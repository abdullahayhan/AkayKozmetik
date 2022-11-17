using BLL.RepositoryPattern.Base_Abstract_;
using BLL.RepositoryPattern.Concrete;
using BLL.RepositoryPattern.Interfaces;
using DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>(options=>options.UseSqlServer(configuration["ConnectionStrings:Mssql"]));
            services.AddRazorPages();
          
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
               options => {
                   options.LoginPath = "/Home/LoginAsAdmin";
                   options.Cookie.Name = "UserDetail";
                   options.AccessDeniedPath = "/Home/LoginAsAdmin";
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "admin"));
            });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); // wwwroot dosyasýný kullanabilmek için. statik dosyalara eriþim saðlamak için.
            app.UseRouting();
            app.UseAuthentication(); // giriþ için 
            app.UseAuthorization(); // giriþ kontrölü için
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "DefaultArea",
                  pattern: "{area:exists}/{controller=Product}/{action=GetList}"
                  );
                endpoints.MapControllerRoute(
                    name:"Default",
                    pattern:"{controller=Home}/{action=Index}"
                    );
            });
        }
    }
}
