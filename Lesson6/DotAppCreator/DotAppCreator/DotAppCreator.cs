using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CommandInterface;

namespace DotAppCreator
{
    class DotAppCreator
    {
        Dictionary<string, ICommand> _commands;
        public DotAppCreator()
        {
            LoadCommandsForAssembly(new[] { Assembly.GetExecutingAssembly() });
        }
        public DotAppCreator(params Assembly[] commandAssemblies)
        {
            LoadCommandsForAssembly(commandAssemblies);
        }

        private void LoadCommandsForAssembly(Assembly[] assemblies)
        {
            var commandTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(type => typeof(ICommand).IsAssignableFrom(type))
                .Where(type => !type.IsAbstract)
                .Where(type => type.Name.EndsWith("Command"));

            _commands = commandTypes.ToDictionary(type => type.Name.Substring(0, type.Name.Length - "Command".Length).ToLower(), type => (ICommand)Activator.CreateInstance(type));
        }

        public void ExecuteCommand(string commandText)
        {
            var (commandName, projName, path) = SplitCommandText(commandText);
            if (string.IsNullOrEmpty(commandName)
                || string.IsNullOrEmpty(projName)
                || string.IsNullOrEmpty(projName))
            {
                return;
            }

            if (_commands.TryGetValue(commandName, out ICommand command))
            {
                if (projName.StartsWith('"') && projName.EndsWith('"'))
                {
                    command.Execute(projName.Trim('"'), path);
                    Console.WriteLine($"Project {projName} has been created!");
                }
            }
            else
            {
                Console.WriteLine($"Command \"dotcreate {commandName}\" is not supported");
            }
        }
        private (string commandName, string projName, string path) SplitCommandText(string commandText)
        {
            if (commandText.StartsWith("dotcreate"))
            {
                string[] result = commandText.Substring("dotcreate".Length).Trim().Split(' ');

                return result.Length == 3 ? (result[0], result[1], result[2]) : default;
            }
            else
            {

                return default;
            }
        }
    }
}
