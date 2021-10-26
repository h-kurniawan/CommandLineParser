using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();
            var commandLine = BuildCommandLine(serviceProvider);

            await commandLine.InvokeAsync(args).ConfigureAwait(false);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddAdminTaskCommands();

            return services.BuildServiceProvider();
        }

        private static Parser BuildCommandLine(ServiceProvider serviceProvider)
        {
            var commandLineBuilder = new CommandLineBuilder();

            foreach (Command command in serviceProvider.GetServices<Command>())
            {
                commandLineBuilder.AddCommand(command);
            }

            return commandLineBuilder.UseDefaults().Build();
        }
    }
}
