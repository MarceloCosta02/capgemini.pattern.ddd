using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace apiPatternDDD.Domain.Interfaces.Repository
{
    public interface IHeroRepository
    {
        /// <summary>
        /// Metodo para inclusao de Heroís na Base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        void InsertAsync(Hero hero);

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        Task<Hero> GetById(int heroId);

        /// <summary>
        /// Metodo para Atualizar o heroí na base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        void UpdateAsync(Hero hero);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Hero>> GetAll();

        /// <summary>
        /// SaveChangeAsync
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangeAsync();
    }
}
