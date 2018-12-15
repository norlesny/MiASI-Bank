namespace MiASI_Bank.InterfejsBanku.Commands
{
	public class ZalozKontoCommand : BaseBankCommand
	{
		public ZalozKontoCommand(IBankAccessor bank) : base(bank, "zaloz-konto")
		{ }

		public override void Invoke(string[] param)
		{
			var name = QueryParam<string>("Podaj nazwę", param);
			
			bank.ZalozKonto(name);
		}
	}
}