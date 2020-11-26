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
        public Task<IEnumerable<Hero>> GetAllHeros()
        {
            var heros = _repo.GetAll();
            return heros;
        }

        /// <summary>
        /// GetHeroById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public async Task<Hero> GetHeroById(int heroId)
        {
            var result = await _repo.GetById(heroId);
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
        public async void InsertHeroAsync(Hero hero)
        {
            _repo.InsertAsync(hero);

            if (!await _repo.SaveChangeAsync())
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Metodo que invoca o update de Heroís
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public async void UpdateHeroAsync(Hero hero, int heroId)
        {
            var result = await _repo.GetById(heroId);

            if (result == null)
                throw new NotImplementedException($"Não foi encontrado um Heroí com o ID: {heroId}.");
            else
            {
                _repo.UpdateAsync(hero);

                if (!await _repo.SaveChangeAsync())
                    throw new InvalidOperationException();
            }
        }
    }

}
