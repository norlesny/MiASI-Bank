namespace MiASI_Bank
{
	public interface IBankAccessor
	{
		IWlasciciel Konto { get; set; }

		bool ZmienKonto(string name);
		void ZalozKonto(string name);
		
		bool PodajLiczbeRachunkow(out int liczbaRachunkow);
		
		bool DodajRachunek();
	}
}