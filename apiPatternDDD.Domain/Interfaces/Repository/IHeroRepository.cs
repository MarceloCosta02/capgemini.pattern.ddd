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
        void Insert(Hero hero);

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        Hero GetById(int heroId);

        /// <summary>
        /// Metodo para Atualizar o heroí na base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        void Update(Hero hero);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        IEnumerable<Hero> GetAll();

        /// <summary>
        /// SaveChange
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
