namespace MiASI_Bank.Produkt.Interfejsy
{
    public interface IRachunekBankowy : IProduktBankowy
    {
        bool Zamknij();
        bool DodajLokate(Kwota kwota, out Lokata lokata);
        bool DodajKredyt(Kwota kwota);
        bool DodajDebet(Kwota limit);
        bool PodajLiczbeLokat(out int liczbaLokat);
        bool WplacGotowke(Kwota kwota);
        bool WyplacGotowke(Kwota kwota);
        bool ZerwijLokate(NumerProduktu numerProduktu);
    }
}