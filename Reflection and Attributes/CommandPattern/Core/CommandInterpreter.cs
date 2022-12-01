namespace CommandPattern.Core.Contracts
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string commandName = tokens[0];
            tokens = tokens.Skip(1).ToArray();

            Assembly currentAssembly = Assembly.GetEntryAssembly();
            Type[] Types = currentAssembly.GetTypes();
            Type commandType = (Type)Types.FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            MethodInfo executeMethod = commandType.GetMethods(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(m => m.Name == "Execute");

            if (executeMethod == null)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            
            object commandInstance = Activator.CreateInstance(commandType);
            string result = (string)executeMethod.Invoke(commandInstance, new object[] { tokens });

            return result;
        }
    }
}
