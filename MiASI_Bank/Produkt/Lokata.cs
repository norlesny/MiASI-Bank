using System;

namespace MiASI_Bank
{
    public class Lokata: ProduktBankowy
    {
        public RachunekBankowy Rachunek { get; set; }

        public Lokata(RachunekBankowy rachunek, Kwota kwota)
        {
            Rachunek = rachunek;
            Numer = new NumerProduktu();
            Saldo = kwota;
        }

        public bool Zerwij()
        {
            //TODO
            return Rachunek.WplacGotowke(Saldo);
        }
    }
}