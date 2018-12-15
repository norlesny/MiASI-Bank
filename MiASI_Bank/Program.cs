using Tharga.Toolkit.Console;
using Tharga.Toolkit.Console.Commands;
using Tharga.Toolkit.Console.Consoles;

namespace MiASI_Bank
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			using (var console = new ClientConsole())
			{
				var rootCommand = new RootCommand(console);

				rootCommand.RegisterCommand(new InterfejsBanku.InterfejsBanku());

				var commandEngine = new CommandEngine(rootCommand);
				commandEngine.Start(args);
			}
		}
	}
}