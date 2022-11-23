namespace PersonInfo.Core
{
    using System;

    using Models;
    using Models.Interfaces;

    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
