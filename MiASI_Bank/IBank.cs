using System;

namespace MiASI_Bank
{
    public interface IBank
    {
        bool DodajKredyt(Wlasciciel wlasciciel, Kwota kwota);
        bool DodajLokate(Wlasciciel wlasciciel, Kwota kwota, out Lokata lokata);
        bool DodajRachunek(Wlasciciel wlasciciel, out IRachunekBankowy rachunek);
        Raport GenerujRaport();
        Raport PobierzSaldo(IRachunekBankowy produkt);
        bool WplacGotowke(IRachunekBankowy cel, Kwota kwota);
        bool WykonajPrzelew(IRachunekBankowy zrodlo, IRachunekBankowy cel, Kwota kwota);
        bool WyplacGotowke(IRachunekBankowy zrodlo, Kwota kwota);
        bool ZamknijRachunek(Wlasciciel wlasciciel);
        bool ZerwijLokate(Wlasciciel wlasciciel, NumerProduktu numerProduktu);
        
        bool PodajLiczbeRachunkow(out int liczbaRachunkow);
        bool PodajLiczbeLokat(Wlasciciel wlasciciel, out int liczbaLokat);
    }
}