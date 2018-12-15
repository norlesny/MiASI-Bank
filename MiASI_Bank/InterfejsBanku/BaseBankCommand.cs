using Tharga.Toolkit.Console.Commands.Base;

namespace MiASI_Bank.InterfejsBanku
{
	public abstract class BaseBankCommand : ActionCommandBase
	{
		protected readonly IBankAccessor bank;

		protected BaseBankCommand(IBankAccessor bank, string name, string description = null, bool hidden = false)
			: base(name, description, hidden)
		{
			this.bank = bank;
		}
	}
}