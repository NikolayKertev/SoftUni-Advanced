using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public string Size { get; private set; }
        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    price = value * 2 / 3;
                }
                else if (Size == "Small")
                {
                    price = value * 1 / 3;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({Size}) - {Price:f2} lv");

            return sb.ToString().Trim();
        }
    }
}
