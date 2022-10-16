using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }

            var oldestPerson = family.OlderThan();

            foreach (var person in oldestPerson)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
