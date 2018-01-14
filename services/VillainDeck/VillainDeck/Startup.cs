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

namespace VillainDeck
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
            services.AddSingleton<SchemeHttpClient, SchemeHttpClient>();
            services.AddTransient<ISchemeDAO, SchemeDAO>();
            services.AddTransient<ISchemeBLC, SchemeBLC>();
            
            services.AddSingleton<MastermindHttpClient, MastermindHttpClient>();
            services.AddTransient<IMastermindDAO, MastermindDAO>();
            services.AddTransient<IMastermindBLC, MastermindBLC>();

            services.AddSingleton<VillainHttpClient, VillainHttpClient>();
            services.AddTransient<IVillainDAO, VillainDAO>();
            services.AddTransient<IVillainBLC, VillainBLC>();

            services.AddSingleton<HenchmanHttpClient, HenchmanHttpClient>();
            services.AddTransient<IHenchmanDAO, HenchmanDAO>();
            services.AddTransient<IHenchmanBLC, HenchmanBLC>();
            
            services.AddTransient<IVillainDeckBLC, VillainDeckBLC>();

            services.AddMvc();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "VillainDeck",
                    Version = "v1",
                    Description = "Service used to retrieve the Villain Deck"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "VillainDeck");
            });
        }
    }
}
