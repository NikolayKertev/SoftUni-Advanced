namespace BorderControl.Models
{
    using Interfaces;
    using System.Numerics;

    public class Robot : ICharacter
    {
        private string name;

        public Robot(string name, string id)
        {
            this.name = name;
            Id = id;
        }

        public string Id { get; private set; }
    }
}
