namespace Raiding.Factories
{
    using System;
    using System.Collections.Generic;
    using Models.Interfaces;
    using Raiding.Models;

    public class HeroFactory
    {
        public IBaseHero CreateHero()
        {
            string name;
            string type;
            IBaseHero hero = null;

            name = Console.ReadLine();
            type = Console.ReadLine();
            
            hero = CreateClassHero(name, type);

            return hero;
        }

        private IBaseHero CreateClassHero(string name, string type)
        {
            IBaseHero hero;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
