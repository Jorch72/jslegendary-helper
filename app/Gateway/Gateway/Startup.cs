using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Gateway
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
            services.AddSingleton<EditionHttpClient, EditionHttpClient>();
            services.AddTransient<IEditionDAO, EditionDAO>();
            services.AddTransient<IEditionBLC, EditionBLC>();

            services.AddSingleton<FilterHttpClient, FilterHttpClient>();
            services.AddTransient<IFilterDAO, FilterDAO>();
            
            services.AddSingleton<VillainDeckHttpClient, VillainDeckHttpClient>();
            services.AddTransient<IVillainDeckDAO, VillainDeckDAO>();
            services.AddTransient<IVillainDeckBLC, VillainDeckBLC>();
            
            services.AddSingleton<HeroDeckHttpClient, HeroDeckHttpClient>();
            services.AddTransient<IHeroDeckDAO, HeroDeckDAO>();
            services.AddTransient<IHeroDeckBLC, HeroDeckBLC>();

            services.AddMvc();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "Gateway",
                    Version = "v1",
                    Description = "Service used to orchestrate the game setup"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "Gateway");
            });

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index" });
            });
        }
    }
}
