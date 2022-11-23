namespace BorderControl.Models
{
    using Interfaces;
    using System.Numerics;

    public class Citizen : ICharacter
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            Id = id;
        }

        public string Id { get; private set; }
    }
}
