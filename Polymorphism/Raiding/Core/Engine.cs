namespace Raiding.Core
{
    using System;

    using Interfaces;
    using System.Collections.Generic;

    using Factories;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private HeroFactory factory;
        private List<IBaseHero> heroes;
        public Engine()
        {
            factory = new HeroFactory();
            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int nHeroesToCreate = int.Parse(Console.ReadLine());

            AddHeroes(nHeroesToCreate);

            int bossPower = int.Parse(Console.ReadLine());

            int totalPower = UseAbilities(heroes);

            Console.WriteLine(FightBoss(totalPower, bossPower));

        }

        private void AddHeroes(int nHeroesToCreate)
        {
            for (int i = 0; i < nHeroesToCreate; i = heroes.Count)
            {
                try
                {
                    heroes.Add(factory.CreateHero());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private int UseAbilities(List<IBaseHero> heroes)
        {
            int totalPower = 0;

            foreach (IBaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());

                totalPower += hero.Power;
            }

            return totalPower;
        }
        private string FightBoss(int totalPower, int bossPower)
        {
            if (bossPower > totalPower)
            {
                return "Defeat...";
            }

            return "Victory!";
        }
    }
}
