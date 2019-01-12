using MiASI_Bank.Interesanci.Interfejsy;
using MiASI_Bank.Produkt.Interfejsy;

namespace MiASI_Bank.Produkt.Fabryki.Interfejsy
{
    public interface IFabrykaRachunkow
    {
        IRachunekBankowy StworzRachunek(IWlasciciel wlasciciel);
    }
}