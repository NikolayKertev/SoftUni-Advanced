namespace FoodShortage.Models
{
    using Interfaces;
    public class Rebel : ICharacter, IBuyer
    {
        private string group;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            this.group = group;
            Food = 0;
            CharacterType = "Rebel";
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string CharacterType { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
