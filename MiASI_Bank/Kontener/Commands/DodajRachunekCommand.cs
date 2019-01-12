using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class DodajRachunekCommand : BaseBankCommand
	{
		public DodajRachunekCommand(IBankAccessor bank) : base(bank, "dodaj-rachunek")
		{ }

//		public override bool CanExecute(out string reasonMessage)
//		{
//			if (bank.Konto == null)
//			{
//				reasonMessage = "Brak zalogowanego konta";
//				return false;
//			}
//
//			reasonMessage = "Konto jest zalogowane";
//			return true;
//		}

		public override void Invoke(string[] param)
		{
			if (Bank.DodajRachunek())
			{
				OutputInformation("Dodano rachunek");
			}
			else
			{
				OutputWarning("Nie udało się dodać rachunku");
			}
		}
	}
}