using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputData = args.Split();
            string commandName = inputData[0] + "Command";
            string[] parameters = inputData.Skip(1).ToArray();
            Type type = Assembly.GetCallingAssembly().GetTypes()
                .Where(x => x.Name == commandName).FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }
            ICommand command = (ICommand)Activator.CreateInstance(type);
            return command.Execute(parameters);
        }
    }
}