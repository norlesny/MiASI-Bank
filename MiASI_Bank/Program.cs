using SimpleInjector;
using Tharga.Toolkit.Console;
using Tharga.Toolkit.Console.Commands;
using Tharga.Toolkit.Console.Consoles;

namespace MiASI_Bank
{
	internal class Program
	{
		private static readonly Container container;

		static Program()
		{
			container = new Container();

			container.Register<IBankAccessor, BankAccessor>();
			container.Register<IBank, Bank>();
			container.Register<IFabrykaRachunkow, FabrykaRachunkow>();
			container.Register<InterfejsBanku.InterfejsBanku>();
			
			container.Verify();
		}

		private static void Main(string[] args)
		{
			using (var console = new ClientConsole())
			{
				var rootCommand = new RootCommand(console);

				rootCommand.RegisterCommand(container.GetInstance<InterfejsBanku.InterfejsBanku>());

				var commandEngine = new CommandEngine(rootCommand);
				commandEngine.Start(args);
			}
		}
	}
}