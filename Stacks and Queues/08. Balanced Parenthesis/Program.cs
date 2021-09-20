using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> leftPar = new Stack<char>();
            Queue<char> rightPar = new Queue<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    leftPar.Push(symbol);
                }
                else if (symbol == ')' || symbol == '}' || symbol == ']')
                {
                    rightPar.Enqueue(symbol);
                }
            }

            bool isValid = false;

            while (leftPar.Any() && rightPar.Any())
            {
                isValid = true;
                char stackPar = leftPar.Peek();
                char queuePar = rightPar.Peek();

                if (leftPar.Count != rightPar.Count)
                {
                    isValid = false;
                    break;
                }
                else if (stackPar == '(' && queuePar == ')' || stackPar == '{' && queuePar == '}' || stackPar == '[' && queuePar == ']')
                {
                    leftPar.Pop();
                    rightPar.Dequeue();
                }
                else
                { 
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else if (!isValid)
            {
                Console.WriteLine("NO");
            }
        }
    }
}
