using System;
using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class AktualneKontoCommand : BaseBankCommand
	{
		public AktualneKontoCommand(IBankAccessor bank) : base(bank, "aktualne-konto")
		{ }

		public override void Invoke(string[] param)
		{
			if (Bank.Konto != null)
			{
				Console.WriteLine($"Jesteś zalogowany na konto o nazwie: {Bank.Konto.Name}");
			}
			else
			{
				Console.WriteLine("Nie jesteś zalogowany na żadne konto");
			}
		}
	}
}