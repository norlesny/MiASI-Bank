using MiASI_Bank.InterfejsBanku.Commands;
using Tharga.Toolkit.Console.Commands.Base;

namespace MiASI_Bank.InterfejsBanku
{
	public class InterfejsBanku : ContainerCommandBase
	{
		public InterfejsBanku() : base("bank")
		{
			// TODO: Inhect
			var bank = new BankAccessor();

			RegisterCommand(new PodajLiczbeRachunkowCommand(bank));
		}
	}
}