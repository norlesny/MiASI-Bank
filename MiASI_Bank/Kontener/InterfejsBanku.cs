using MiASI_Bank.Instytucja.Interfejsy;
using MiASI_Bank.Kontener.Commands;
using Tharga.Toolkit.Console.Commands.Base;

namespace MiASI_Bank.Kontener
{
	public class InterfejsBanku : ContainerCommandBase
	{
		public InterfejsBanku(IBankAccessor bank) : base("bank")
		{
			RegisterCommand(new PodajLiczbeRachunkowCommand(bank));
			RegisterCommand(new ZalozKontoCommand(bank));
			RegisterCommand(new AktualneKontoCommand(bank));
			RegisterCommand(new ZmienKontoCommand(bank));
			RegisterCommand(new DodajRachunekCommand(bank));
			RegisterCommand(new WyswietlKontaCommand(bank));
		}
	}
}