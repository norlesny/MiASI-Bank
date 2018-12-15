using System.Collections.Generic;
using System.Linq;

namespace MiASI_Bank
{
	public class BankAccessor : IBankAccessor
	{
		private readonly ICollection<IWlasciciel> accounts;

		private readonly IBank bank;

		public BankAccessor(IBank bank)
		{
			this.bank = bank;

			accounts = new List<IWlasciciel>();
		}

		public IWlasciciel Konto { get; set; }

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

		public bool PodajLiczbeRachunkow(out int liczbaRachunkow)
		{
			return bank.PodajLiczbeRachunkow(out liczbaRachunkow);
		}

		public bool DodajRachunek()
		{
			if (Konto == null)
			{
				return false;
			}

			return bank.DodajRachunek(Konto, out _);
		}

		public IReadOnlyCollection<IWlasciciel> PobierzKonta()
		{
			return (IReadOnlyCollection<IWlasciciel>) accounts;
		}
	}
}