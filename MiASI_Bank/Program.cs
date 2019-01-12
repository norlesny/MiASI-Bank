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
		private static readonly Container Container;

		static Program()
		{
			Container = new Container();

			Container.Register<IBankAccessor, BankAccessor>();
			Container.Register<IBank, Bank>();
			Container.Register<IFabrykaRachunkow, FabrykaRachunkow>();
			Container.Register<Kontener.InterfejsBanku>();
			
			Container.Verify();
		}

		private static void Main(string[] args)
		{
            var config = new ConsoleConfiguration {SplashScreen = "Best Bank ever"};

            using (var console = new ClientConsole(config))
			{
				var rootCommand = new RootCommand(console);

				rootCommand.RegisterCommand(Container.GetInstance<Kontener.InterfejsBanku>());

				var commandEngine = new CommandEngine(rootCommand);

				commandEngine.Start(args);
			}
		}
	}
}