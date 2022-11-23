namespace FoodShortage.Models
{
    using Interfaces;
    public class Citizen : ICharacter, IBirthable, IBuyer
    {
        private string id;

        public Citizen(string name, int age, string id, string day, string month, string year)
        {
            this.id = id;
            Age = age;
            Name = name;
            Day = day;
            Month = month;
            Year = year;
            Food = 0;
            CharacterType = "Citizen";
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Year { get; private set; }
        public int Food { get; private set; }
        public string CharacterType { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
