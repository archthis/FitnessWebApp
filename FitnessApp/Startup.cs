using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FitnessAPP.DATA;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                       

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup()
        {
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Specify the correct life time of the ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

            services.AddMvc();
            services.AddAutoMapper(cfg => cfg.CreateMissingTypeMaps = true);

            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IEntriesRepository, EntriesRepository>();


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceScopeFactory scopeFactory)
        {
            // seed data
            if (env.IsDevelopment())
            {
                scopeFactory.SeedData();
            }
                       
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
             
                app.UseStatusCodePagesWithReExecute("/Home/Errors/{0}");

            }
            else
            {
                app.UseExceptionHandler("/Home/ServerError");
                app.UseStatusCodePagesWithReExecute("/Home/Errors/{0}");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
