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
            List<ICharacter> characters = new List<ICharacter>();

            string input;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                switch (tokens.Length)
                {
                    case 2:
                        string id = tokens[1];

                        ICharacter robot = new Robot(name, id);
                        characters.Add(robot);
                        break;
                    case 3:
                        int age = int.Parse(tokens[1]);
                        id = tokens[2];

                        ICharacter citizen = new Citizen(name, age, id);
                        characters.Add(citizen);
                        break;
                }
            }

            List<string> fakeIDs = new List<string>(); 

            string fakeIdDigits = reader.ReadLine();

            foreach (var character in characters)
            {
                string id = character.Id;

                int counter = 0;

                for (int i = 0; i < fakeIdDigits.Length; i++)
                {
                    if (id[id.Length - i - 1] == fakeIdDigits[fakeIdDigits.Length - i - 1])
                    {
                        counter++;
                    }
                }

                if (counter == fakeIdDigits.Length)
                {
                    fakeIDs.Add(id);
                }
            }

            foreach (var id in fakeIDs)
            {
                writer.WriteLine(id.ToString());
            }
        }
    }
}
