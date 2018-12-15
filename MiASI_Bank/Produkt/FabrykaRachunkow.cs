namespace MiASI_Bank
{
    public class FabrykaRachunkow : IFabrykaRachunkow
    {
        public IRachunekBankowy StworzRachunek(IWlasciciel wlasciciel)
        {
            return new RachunekBankowy(wlasciciel);
        }
    }
}