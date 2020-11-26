using apiPatternDDD.Domain.Interfaces.Repository;
using apiPatternDDD.Domain.Interfaces.Services;
using apiPatternDDD.Infra.Data.Repository;
using apiPatternDDD.Service;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace apiPatternDDD.Infra.CrossCutting.IoC
{
    /// <summary>
    /// NativeInjectorBootStrapper
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// RegisterServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void RegisterServices(IServiceCollection services, Dictionary<Enum, string> config)
        {
            services.AddScoped<IMapper>(sp => new Mapper(
                sp.GetRequiredService<IConfigurationProvider>(),
                sp.GetRequiredService)
            );

            #region Service
            services.AddScoped<IHeroService, HeroService>();
            #endregion

            #region Repository
            services.AddScoped<IHeroRepository, HeroRepository>();
            #endregion
        }
    }
}