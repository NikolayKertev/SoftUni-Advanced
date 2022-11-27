namespace Raiding.Models
{
    public abstract class Healer : BaseHero
    {
        public Healer(string name)
            : base(name){}

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
