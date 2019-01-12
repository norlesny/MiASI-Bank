using System;
using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class PodajLiczbeRachunkowCommand : BaseBankCommand
	{
		public PodajLiczbeRachunkowCommand(IBankAccessor bank) : base(bank, "liczba-rachunkow")
		{ }

		public override void Invoke(string[] param)
		{
			Bank.PodajLiczbeRachunkow(out int count);
			Console.WriteLine($"Liczba znalezionych rachunków: {count}");
		}
	}
}