namespace CommandPattern.Core.Contracts
{
    using System;

    class ExitCommand : ICommand
    {
        private const int EXIT_CODE = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(EXIT_CODE);
            return null;
        }
    }
}
