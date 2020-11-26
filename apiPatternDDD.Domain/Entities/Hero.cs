using System;

namespace apiPatternDDD.Domain
{
    public class Hero 
    {
        public int HeroId { get; set; }
        public string SuperHeroName { get; set; }
        public string RealName { get; set; }
        public string SuperPower { get; set; }
        public string Weapon { get; set; }
        public DateTime BirthDate { get; set; }

        public Hero(int heroId, string superHeroName, string realName, string superPower, string weapon, DateTime birthDate)
        {
            HeroId = heroId;
            SuperHeroName = superHeroName;
            RealName = realName;
            SuperPower = superPower;
            Weapon = weapon;
            BirthDate = birthDate;
        }
    }
}
