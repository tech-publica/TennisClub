using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TennisClubWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages()
                .UseStaticFiles()
                .UseMvc(routes =>
               {
                   routes.MapRoute(
                       name: "pagination",
                       template: "Reservations/Page/{page}",
                       defaults: new { Controller = "Reservations", Action = "List" }
                        );
                   routes.MapRoute(
                       name: "default",
                       template: "{controller=Reservations}/{action=index}/{id?}"
                       );
               });
        }
    }
}
