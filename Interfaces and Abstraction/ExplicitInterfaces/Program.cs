namespace ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Interfaces;
    class Program
    {
        static void Main(string[] args)
        {
            List<IResident> residents = new List<IResident>();
            List<IPerson> people = new List<IPerson>();

            string input;
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, age, country);

                IResident resident = citizen;
                residents.Add(resident);

                IPerson person = citizen;
                people.Add(person);
            }

            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}
