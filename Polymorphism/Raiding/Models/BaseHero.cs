namespace Raiding.Models
{
    using Interfaces;

    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
