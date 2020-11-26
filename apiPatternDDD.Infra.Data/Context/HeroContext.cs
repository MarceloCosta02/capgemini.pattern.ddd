using apiPatternDDD.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace apiPatternDDD.Infra.Data
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        public DbSet<Hero> Hero { get; set; }     
    }
}
