﻿using System;

namespace MiASI_Bank
{
    public interface IBank
    {
        bool DodajKredyt(IWlasciciel wlasciciel, Kwota kwota);
        bool DodajLokate(IWlasciciel wlasciciel, Kwota kwota, out Lokata lokata);
        bool DodajRachunek(IWlasciciel wlasciciel, out IRachunekBankowy rachunek);
        Raport GenerujRaport();
        Raport PobierzSaldo(IRachunekBankowy produkt);
        bool WplacGotowke(IRachunekBankowy cel, Kwota kwota);
        bool WykonajPrzelew(IRachunekBankowy zrodlo, IRachunekBankowy cel, Kwota kwota);
        bool WyplacGotowke(IRachunekBankowy zrodlo, Kwota kwota);
        bool ZamknijRachunek(IWlasciciel wlasciciel);
        bool ZerwijLokate(IWlasciciel wlasciciel, NumerProduktu numerProduktu);
        
        bool PodajLiczbeRachunkow(out int liczbaRachunkow);
        bool PodajLiczbeLokat(IWlasciciel wlasciciel, out int liczbaLokat);

        IRachunekBankowy PobierzRachunek(IWlasciciel wlasciciel);
    }
}