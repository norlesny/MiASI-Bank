using System.Collections.Generic;
using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class WyswietlKontaCommand : BaseBankCommand
	{
		public WyswietlKontaCommand(IBankAccessor bank) : base(bank, "wyswietl-konta")
		{ }

		public override void Invoke(string[] param)
		{
			var konta = Bank.PobierzKonta();

			var table = new List<string[]> {new[] {"Index", "Nazwa"}};
			foreach (var konto in konta)
				table.Add(new[] {konto.Id.ToString(), konto.Name});

			OutputTable(table);
		}
	}
}