using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPatternDDD.Domain.Interfaces.Repository;
using apiPatternDDD.Domain.Interfaces.Services;
using apiPatternDDD.Infra.Data;
using apiPatternDDD.Infra.Data.Repository;
using apiPatternDDD.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using apiPatternDDD.Infra.CrossCutting;
using apiPatternDDD.Infra.CrossCutting.IoC;

namespace apiPatternDDD
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
            // Adicionando o contexto via lambda expression via inje��o de dependencia
            services.AddDbContext<HeroContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            RegisterService(services);

            services.AddControllers().AddNewtonsoftJson();
            services.ConfigurarSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }                       

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UtilizarConfiguracaoSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterService(IServiceCollection services)
        {
            var parametros = new Dictionary<Enum, string>();
            NativeInjectorBootStrapper.RegisterServices(services, parametros);
        }
    }
}
