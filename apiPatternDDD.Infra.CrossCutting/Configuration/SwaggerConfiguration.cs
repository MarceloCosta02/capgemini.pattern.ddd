using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace apiPatternDDD.Infra.CrossCutting
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Hero V1",
                    Description = "Hero V1"
                });

            });

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hero API V1");
                c.DocumentTitle = "Hero API";
                c.DocExpansion(DocExpansion.None);
            });
            return app;
        }
    }
}
