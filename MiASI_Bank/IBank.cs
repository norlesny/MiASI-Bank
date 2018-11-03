namespace MiASI_Bank
{
    public interface IBank
    {
        System.Boolean DodajKredyt(Wlasciciel wlasciciel, Kwota kwota);
        System.Boolean DodajLokate(Wlasciciel wlasciciel, Kwota kwota);
        System.Boolean DodajRachunek(Wlasciciel wlasciciel);
        Raport GenerujRaport();
        Raport PobierzSaldo(RachunekBankowy produkt);
        System.Boolean WplacGotowke(RachunekBankowy cel, Kwota kwota);
        System.Boolean WykonajPrzelew(RachunekBankowy zrodlo, RachunekBankowy cel, Kwota kwota);
        System.Boolean WyplacGotowke(RachunekBankowy zrodlo, Kwota kwota);
        System.Boolean ZamknijRachunek(Wlasciciel wlasciciel);
        System.Boolean ZerwijLokate(NumerProduktu numerProduktu);
    }
}