using System;

namespace MiASI_Bank.InterfejsBanku.Commands
{
	public class PodajLiczbeRachunkowCommand : BaseBankCommand
	{
		public PodajLiczbeRachunkowCommand(IBankAccessor bank) : base(bank, "liczba-rachunkow")
		{ }

		public override void Invoke(string[] param)
		{
			bank.Bank.PodajLiczbeRachunkow(out int count);
			Console.WriteLine($"Liczba znalezionych rachunków: {count}");
		}
	}
}