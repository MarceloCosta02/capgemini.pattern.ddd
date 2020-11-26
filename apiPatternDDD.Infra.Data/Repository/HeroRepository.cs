using apiPatternDDD.Domain;
using apiPatternDDD.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiPatternDDD.Infra.Data.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Hero>> GetAll()
        {
            IQueryable<Hero> query = _context.Hero;           

            query = query
                .AsNoTracking()
                .OrderBy(p => p.HeroId);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public async Task<Hero> GetById(int heroId)
        {
            IQueryable<Hero> query = _context.Hero;      

            query = query
                .AsNoTracking()
                .OrderBy(h => h.HeroId);

            return await query.FirstOrDefaultAsync(h => h.HeroId == heroId);
        }

        /// <summary>
        /// Metodo para inclusao de Heroís na Base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void InsertAsync(Hero hero)
        {
            _context.Add(hero);
        }

        /// <summary>
        /// Metodo para Atualizar o heroí na base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void UpdateAsync(Hero hero)
        {
            _context.Update(hero);
        }

        /// <summary>
        /// SaveChangeAsync
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
