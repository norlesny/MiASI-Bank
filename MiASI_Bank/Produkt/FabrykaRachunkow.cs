namespace MiASI_Bank
{
    public class FabrykaRachunkow : IFabrykaRachunkow
    {
        public IRachunekBankowy StworzRachunek(Wlasciciel wlasciciel)
        {
            return new RachunekBankowy(wlasciciel);
        }
    }
}