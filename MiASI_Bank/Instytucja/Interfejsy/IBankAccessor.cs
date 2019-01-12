using System.Collections.Generic;
using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;

namespace MiASI_Bank.Instytucja.Interfejsy
{
	public interface IBankAccessor
	{
		IWlasciciel Konto { get; set; }

		bool ZmienKonto(string name);
		void ZalozKonto(string name);
		
		bool PodajLiczbeRachunkow(out int liczbaRachunkow);
		
		bool DodajRachunek();

		IReadOnlyCollection<IWlasciciel> PobierzKonta();
	}
}