using System;

namespace MiASI_Bank.InterfejsBanku.Commands
{
	public class DodajRachunekCommand:BaseBankCommand
	{
		public DodajRachunekCommand(IBankAccessor bank):base(bank, "dodaj-rachunek"){}


		public override void Invoke(string[] param)
		{
			if (bank.DodajRachunek())
			{
				Console.WriteLine("Dodano rachunek");
			}
			else
			{
				Console.WriteLine("Nie udało się dodać rachunku");
			}
		}
	}
}