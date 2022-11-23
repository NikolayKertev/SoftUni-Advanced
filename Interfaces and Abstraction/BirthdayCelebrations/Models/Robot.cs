namespace BorderControl.Models
{
    using Interfaces;
    using System;
    using System.Numerics;

    public class Robot : ICharacter
    {
        private string id;

        public Robot(string name, string id)
        {
            this.id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
