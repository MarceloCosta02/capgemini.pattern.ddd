using apiPatternDDD.Domain;
using apiPatternDDD.Domain.Interfaces.Repository;
using apiPatternDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPatternDDD.Service
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _repo;

        public HeroService(IHeroRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Hero> GetAllHeros()
        {
            var heros = _repo.GetAll();
            return heros;
        }

        /// <summary>
        /// GetHeroById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public Hero GetHeroById(int heroId)
        {
            var result = _repo.GetById(heroId);
            if (result == null)
                throw new NotImplementedException($"Não foi encontrado um Heroí com o ID: {heroId}.");
            else
                return result;
        }

        /// <summary>
        /// Método que invoca o insert de Heroís
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void InsertHero(Hero hero)
        {
            _repo.Insert(hero);

            if (!_repo.SaveChanges())
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Metodo que invoca o update de Heroís
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void UpdateHero(Hero hero, int heroId)
        {
            var result = _repo.GetById(heroId);

            if (result == null)
                throw new NotImplementedException($"Não foi encontrado um Heroí com o ID: {heroId}.");
            else
            {
                _repo.Update(hero);

                if (!_repo.SaveChanges())
                    throw new InvalidOperationException();
            }
        }
    }

}
