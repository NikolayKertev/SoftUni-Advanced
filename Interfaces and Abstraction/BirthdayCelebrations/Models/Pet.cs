namespace BorderControl.Models
{
    using System;
    using Interfaces;

    public class Pet : ICharacter, IBirthable
    {
        public Pet(string name, string day, string month, string year)
        {
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
