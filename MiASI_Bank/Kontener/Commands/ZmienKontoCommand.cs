using System;
using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class ZmienKontoCommand : BaseBankCommand
	{
		public ZmienKontoCommand(IBankAccessor bank) : base(bank, "zmien-konto")
		{ }

		public override void Invoke(string[] param)
		{
			var name = QueryParam<string>("Podaj nazwe", param);

			if (Bank.ZmienKonto(name))
			{
				Console.WriteLine($"Jesteś teraz zalogowany na konto o nazwie: {Bank.Konto.Name}");
			}
			else
			{
				Console.WriteLine("Nie znaleziono konta o podanej nazwie");
			}
		}
	}
}