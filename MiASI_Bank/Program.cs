using MiASI_Bank.Instytucja;
using MiASI_Bank.Instytucja.Interfejsy;
using MiASI_Bank.Produkt.Fabryki;
using MiASI_Bank.Produkt.Fabryki.Interfejsy;
using SimpleInjector;
using Tharga.Toolkit.Console;
using Tharga.Toolkit.Console.Commands;
using Tharga.Toolkit.Console.Consoles;
using Tharga.Toolkit.Console.Entities;

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
			var config = new ConsoleConfiguration();
			config.SplashScreen = "Best Bank ever";
			using (var console = new ClientConsole(config))
			{
				var rootCommand = new RootCommand(console);

				rootCommand.RegisterCommand(container.GetInstance<InterfejsBanku.InterfejsBanku>());

				var commandEngine = new CommandEngine(rootCommand);
				commandEngine.Start(args);
			}
		}
	}
}