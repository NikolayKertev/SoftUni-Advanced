namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FoodShortage.Models;
    using FoodShortage.Models.Interfaces;
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
            Dictionary<string, IBuyer> characters = new Dictionary<string, IBuyer>();

            string input;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];

                string characterType = null;
                if (tokens.Length > 1 && tokens[1].All(ch => char.IsDigit(ch)))
                {
                    if (tokens[2].All(ch => char.IsDigit(ch)))
                    {
                        characterType = "Citizen";
                    }
                    else
                    {
                        characterType = "Rebel";
                    }
                }
                else
                {
                    characterType = "Buyer";
                }

                switch (characterType)
                {
                    case "Citizen":
                        int age = int.Parse(tokens[1]);
                        string id = tokens[2];
                        string[] birthday = tokens[3].Split("/");
                        string day = birthday[0];
                        string month = birthday[1];
                        string year = birthday[2];

                        IBuyer citizen = new Citizen(name, age, id, day, month, year);
                        characters.Add(name, citizen);
                        break;
                    case "Rebel":
                        age = int.Parse(tokens[1]);
                        string group = tokens[2];

                        IBuyer rebel = new Rebel(name, age, group);
                        characters.Add(name, rebel);
                        break;
                    case "Buyer":
                        IBuyer tempBuyer;

                        if (tokens.Length == 1)
                        {
                            if (characters.ContainsKey(name))
                            {
                                tempBuyer = characters[name];
                                tempBuyer.BuyFood();
                            }
                        }
                        break;
                }
            }
            int totalFood = 0;

            foreach (var character in characters)
            {
                totalFood += character.Value.Food;
            }

            writer.WriteLine(totalFood.ToString());
        }
    }
}
