using System;

namespace MiASI_Bank.InterfejsBanku.Commands
{
	public class AktualneKontoCommand : BaseBankCommand
	{
		public AktualneKontoCommand(IBankAccessor bank) : base(bank, "aktualne-konto")
		{ }

		public override void Invoke(string[] param)
		{
			if (bank.Konto != null)
			{
				Console.WriteLine($"Jesteś zalogowany na konto o nazwie: {bank.Konto.Name}");
			}
			else
			{
				Console.WriteLine("Nie jesteś zalogowany na żadne konto");
			}
		}
	}
}