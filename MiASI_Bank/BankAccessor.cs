using System.Collections.Generic;
using System.Linq;

namespace MiASI_Bank
{
	public class BankAccessor : IBankAccessor
	{
		private readonly ICollection<IWlasciciel> accounts;

		public BankAccessor(IBank bank)
		{
			Bank = bank;

			accounts = new List<IWlasciciel>();
		}

		public IWlasciciel Konto { get; set; }
		public IBank Bank { get; }

		public bool ZmienKonto(string name)
		{
			var result = accounts.FirstOrDefault(wlasciciel => wlasciciel.Name == name);
			Konto = result;

			return result != null;
		}

		public void ZalozKonto(string name)
		{
			var wlasciciel = new Wlasciciel(name);
			accounts.Add(wlasciciel);
			Konto = wlasciciel;
		}
	}
}