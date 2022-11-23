namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IBirthable> characters = new List<IBirthable>();

            string input;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string characterType = tokens[0];
                string name = tokens[1];

                switch (characterType)
                {
                    case "Citizen":
                        int age = int.Parse(tokens[2]);
                        string id = tokens[3];
                        string[] birthday = tokens[4].Split("/");
                        string day = birthday[0];
                        string month = birthday[1];
                        string year = birthday[2];

                        IBirthable citizen = new Citizen(name, age, id, day, month, year);
                        characters.Add(citizen);
                        break;
                    case "Pet":
                        birthday = tokens[2].Split("/");
                        day = birthday[0];
                        month = birthday[1];
                        year = birthday[2];

                        IBirthable pet = new Pet(name, day, month, year);
                        characters.Add(pet);
                        break;
                    case "Robot":

                        break;
                }
            }

            string yearToLookFor = reader.ReadLine();
            int counter = 0;

            foreach (var character in characters)
            {
                if (character.Year == yearToLookFor)
                {
                    writer.WriteLine(character.ToString());

                    counter++;
                }
            }
        }
    }
}
