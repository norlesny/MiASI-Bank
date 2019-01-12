using MiASI_Bank.Instytucja.Interfejsy;

namespace MiASI_Bank.Kontener.Commands
{
	public class ZalozKontoCommand : BaseBankCommand
	{
		public ZalozKontoCommand(IBankAccessor bank) : base(bank, "zaloz-konto")
		{ }

		public override void Invoke(string[] param)
		{
			var name = QueryParam<string>("Podaj nazwę", param);
			
			Bank.ZalozKonto(name);
		}
	}
}