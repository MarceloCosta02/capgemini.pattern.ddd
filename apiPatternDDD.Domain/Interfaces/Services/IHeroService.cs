using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace apiPatternDDD.Domain.Interfaces.Services
{
    public interface IHeroService
    {
        /// <summary>
        /// Método que invoca o insert de Heroís
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        void InsertHero(Hero hero);

        /// <summary>
        /// GetHeroById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        Hero GetHeroById(int heroId);

        /// <summary>
        /// Metodo que invoca o update de Heroís
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        void UpdateHero(Hero hero, int heroId);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        IEnumerable<Hero> GetAllHeros();   
    }
}
