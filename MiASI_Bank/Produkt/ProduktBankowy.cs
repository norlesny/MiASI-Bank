using System;

namespace MiASI_Bank
{
    public class ProduktBankowy
    {
        public NumerProduktu Numer { get; set; }
        public Wlasciciel Wlasciciel { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Kwota Saldo { get; }
        public Historia Historia { get; set; }
        public Odsetki Odsetki { get; set; }

        public bool WplacGotowke(Kwota kwota)
        {
            Saldo.Wartosc += kwota.Wartosc;

            return true;
        }
        public bool WyplacGotowke(Kwota kwota)
        {
            if(Saldo.Wartosc < kwota.Wartosc)
            {
                return false;
            }

            Saldo.Wartosc -= kwota.Wartosc;

            return true;
        }
    }
}