namespace BorderControl.Models
{
    using Interfaces;
    using System;
    using System.Numerics;

    public class Citizen : ICharacter, IBirthable
    {
        private string id;
        private int age;

        public Citizen(string name, int age, string id, string day, string month, string year)
        {
            this.id = id;
            this.age = age;
            Name = name;
            Day = day;
            Month = month;
            Year = year;
        }

        public string Name { get; private set; }
        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Year { get; private set; }

        public override string ToString()
        {
            return $"{Day:d2}/{Month:d2}/{Year}";
        }
    }
}
