namespace Raiding.Models
{
    public abstract class DamageDealer : BaseHero
    {
        protected DamageDealer(string name)
            : base(name){}

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
