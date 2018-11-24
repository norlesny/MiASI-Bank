using System;

namespace MiASI_Bank
{
    public interface IBank
    {
        bool DodajKredyt(Wlasciciel wlasciciel, Kwota kwota);
        bool DodajLokate(Wlasciciel wlasciciel, Kwota kwota, out Lokata lokata);
        bool DodajRachunek(Wlasciciel wlasciciel, out RachunekBankowy rachunek);
        Raport GenerujRaport();
        Raport PobierzSaldo(RachunekBankowy produkt);
        bool WplacGotowke(RachunekBankowy cel, Kwota kwota);
        bool WykonajPrzelew(RachunekBankowy zrodlo, RachunekBankowy cel, Kwota kwota);
        bool WyplacGotowke(RachunekBankowy zrodlo, Kwota kwota);
        bool ZamknijRachunek(Wlasciciel wlasciciel);
        bool ZerwijLokate(Wlasciciel wlasciciel, NumerProduktu numerProduktu);
        
        bool PodajLiczbeRachunkow(out int liczbaRachunkow);
        bool PodajLiczbeLokat(Wlasciciel wlasciciel, out int liczbaLokat);
    }
}