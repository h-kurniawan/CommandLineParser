using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineParser
{
    public static class CommandCollectionExtensions
    {
        public static IServiceCollection AddAdminTaskCommands(this IServiceCollection services)
        {
            Type commandType = typeof(Command);

            IEnumerable<Type> commands = Assembly
                .GetExecutingAssembly()
                .GetExportedTypes()
                .Where(x => commandType.IsAssignableFrom(x));

            foreach (Type command in commands)
            {
                services.AddSingleton(commandType, command);
            }

            return services;
        }
    }
}
