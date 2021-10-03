using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();


            while (input != "Party!")
            {
                var arguments = input.Split();

                if (input.Contains("Double"))
                {
                    string action = arguments[1];

                    CriteriaDouble(action, arguments, names);
                }
                else if (input.Contains("Remove"))
                {
                    string action = arguments[1];

                    CriteriaRemove(action, arguments, names);
                }

                input = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
        }

        private static void CriteriaDouble(string action, string[] arguments, List<string> names)
        {
            List<string> namesToAdd = new List<string>();

            if (action == "StartsWith")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (arguments[2] == names[i].Substring(0, arguments[2].Length))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Add(name);
                }
            }
            else if (action == "EndsWith")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (arguments[2] == names[i].Substring(names[i].Length - arguments[2].Length, arguments[2].Length))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Add(name);
                }
            }
            else if (action == "Length")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Length == int.Parse(arguments[2]))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Add(name);
                }
            }
        }

        private static void CriteriaRemove(string action, string[] arguments, List<string> names)
        {
            List<string> namesToAdd = new List<string>();

            if (action == "StartsWith")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (arguments[2] == names[i].Substring(0, arguments[2].Length))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Remove(name);
                }
            }
            else if (action == "EndsWith")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (arguments[2] == names[i].Substring(names[i].Length - arguments[2].Length, arguments[2].Length))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Remove(name);
                }
            }
            else if (action == "Length")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Length == int.Parse(arguments[2]))
                    {
                        namesToAdd.Add(names[i]);
                    }
                }
                foreach (var name in namesToAdd)
                {
                    names.Remove(name);
                }
            }
        }
    }
}
