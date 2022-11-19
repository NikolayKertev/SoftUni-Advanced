using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in peopleInput)
            {
                var tokens = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var money = int.Parse(tokens[1]);

                try
                {
                    Person person = new Person(name, money);

                    people.Add(person);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            foreach (var item in productsInput)
            {
                var tokens = item.Split("=");

                var name = tokens[0];
                var cost = int.Parse(tokens[1]);

                try
                {
                    Product product = new Product(name, cost);

                    products.Add(product);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string productName = tokens[1];

                Person person = people.FirstOrDefault(n => n.Name == name);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person == null || product == null)
                {
                    break;
                }

                if (!person.BuyProduct(product))
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
