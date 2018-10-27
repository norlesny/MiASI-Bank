namespace MiASI_Bank
{
    public interface IBank
    {
        System.Boolean DodajKredyt(RachunekBankowy rachunek);
        System.Boolean DodajLokate(Wlasciciel wlasciciel, Kwota kwota);
        System.Boolean DodajRachunek(Wlasciciel wlasciciel);
        Raport GenerujRaport();
        Raport PobierzSaldo(ProduktBankowy produkt);
        System.Boolean WplacGotowke(ProduktBankowy cel, Kwota kwota);
        System.Boolean WykonajPrzelew(ProduktBankowy zrodlo, ProduktBankowy cel, Kwota kwota);
        System.Boolean WyplacGotowke(ProduktBankowy zrodlo, Kwota kwota);
        System.Boolean ZamknijRachunek(Wlasciciel wlasciciel);
        System.Boolean ZerwijLokate(NumerProduktu numerProduktu);
    }
}