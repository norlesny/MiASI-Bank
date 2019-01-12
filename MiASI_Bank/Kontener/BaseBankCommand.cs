using MiASI_Bank.Instytucja.Interfejsy;
using Tharga.Toolkit.Console.Commands.Base;

namespace MiASI_Bank.Kontener
{
	public abstract class BaseBankCommand : ActionCommandBase
	{
		protected readonly IBankAccessor Bank;

		protected BaseBankCommand(IBankAccessor bank, string name, string description = null, bool hidden = false)
			: base(name, description, hidden)
		{
			Bank = bank;
		}
	}
}