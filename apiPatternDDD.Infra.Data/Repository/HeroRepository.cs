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
        public IEnumerable<Hero> GetAll()
        {
            IQueryable<Hero> query = _context.Hero;           

            query = query
                .AsNoTracking()
                .OrderBy(p => p.HeroId);

            return query.ToArray();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public Hero GetById(int heroId)
        {
            IQueryable<Hero> query = _context.Hero;      

            query = query
                .AsNoTracking()
                .OrderBy(h => h.HeroId);

            return query.FirstOrDefault(h => h.HeroId == heroId);
        }

        /// <summary>
        /// Metodo para inclusao de Heroís na Base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void Insert(Hero hero)
        {
            _context.Add(hero);
        }

        /// <summary>
        /// Metodo para Atualizar o heroí na base de Dados
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void Update(Hero hero)
        {
            _context.Update(hero);
        }

        /// <summary>
        /// SaveChange
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }
    }
}
