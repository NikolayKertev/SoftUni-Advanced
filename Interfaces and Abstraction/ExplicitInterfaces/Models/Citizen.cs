namespace ExplicitInterfaces.Models
{
    using ExplicitInterfaces.Models.Interfaces;
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
    }
}
