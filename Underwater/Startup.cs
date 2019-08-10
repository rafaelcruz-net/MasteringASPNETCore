using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Underwater.Data;
using Underwater.Middlewares;
using Underwater.Models;
using Underwater.Repositories;

namespace Underwater
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnderwaterRepository, UnderwaterRepository>();

            services.AddDbContext<UnderwaterContext>(options =>
             options.UseSqlServer(
                 _configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<UserAccount>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;
            })
          .AddEntityFrameworkStores<UserDbContext>();


            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.LogRequest();
            app.UseAuthentication();
          

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "UnderwaterRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Aquarium", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            }); 
        }
    }
}
