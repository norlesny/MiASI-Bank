namespace MiASI_Bank
{
	public interface IBankAccessor
	{
		IWlasciciel Konto { get; set; }
		IBank Bank { get; }

		bool ZmienKonto(string name);
		void ZalozKonto(string name);
	}
}