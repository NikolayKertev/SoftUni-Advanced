using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> textStack = new Stack<string>();
            textStack.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "1")
                {
                    sb.Append(input[1]);
                    string text = sb.ToString();
                    textStack.Push(text);
                }
                else if (input[0] == "2")
                {
                    string text = sb.ToString();
                    text = text.Substring(0, text.Length - int.Parse(input[1]));
                    sb.Clear();
                    sb.Append(text);
                    text = sb.ToString();
                    textStack.Push(text);
                }
                else if (input[0] == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (input[0] == "4")
                {
                    textStack.Pop();
                    sb.Clear();
                    string text = textStack.Peek();
                    sb.Append(text);
                }
            }
        }
    }
}
