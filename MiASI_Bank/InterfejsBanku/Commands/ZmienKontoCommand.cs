using System;

namespace MiASI_Bank.InterfejsBanku.Commands
{
	public class ZmienKontoCommand : BaseBankCommand
	{
		public ZmienKontoCommand(IBankAccessor bank) : base(bank, "zmien-konto")
		{ }

		public override void Invoke(string[] param)
		{
			var name = QueryParam<string>("Podaj nazwe", param);

			if (bank.ZmienKonto(name))
			{
				Console.WriteLine($"Jesteś teraz zalogowany na konto o nazwie: {bank.Konto.Name}");
			}
			else
			{
				Console.WriteLine("Nie znaleziono konta o podanej nazwie");
			}
		}
	}
}