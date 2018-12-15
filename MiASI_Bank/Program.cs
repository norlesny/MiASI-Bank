using System;
using Tharga.Toolkit.Console;
using Tharga.Toolkit.Console.Commands;
using Tharga.Toolkit.Console.Consoles;

namespace MiASI_Bank
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var console = new ClientConsole())
			{
				var rootCommand = new RootCommand(console);
				var commandEngine = new CommandEngine(rootCommand);
				commandEngine.Start(args);
			}
		}
	}
}