using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;
using MiASI_Bank.Produkt.Fabryki.Interfejsy;
using MiASI_Bank.Produkt.Interfejsy;

namespace MiASI_Bank.Produkt.Fabryki
{
    public class FabrykaRachunkow : IFabrykaRachunkow
    {
        public IRachunekBankowy StworzRachunek(IWlasciciel wlasciciel)
        {
            return new RachunekBankowy(wlasciciel);
        }
    }
}