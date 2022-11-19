using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person()
        {
            products = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get => name;
            set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NAME_EXCEPTION_MESSAGE));
                }

                name = value;
            }
        }
        private decimal Money
        {
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.MONEY_EXCEPTION_MESSAGE));
                }

                money = value;
            }
        }

        public bool BuyProduct(Product product)
        {
            if (product.Cost > money)
            {
                return false;
            }

            money -= product.Cost;
            products.Add(product);

            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            List<string> boughtProducts = new List<string>();

            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    boughtProducts.Add(product.Name);
                }
            }
            else
            {
                boughtProducts.Add("Nothing bought");
            }

            sb.Append($"{name} - {string.Join(", ", boughtProducts)}");

            return sb.ToString();
        }
    }
}
