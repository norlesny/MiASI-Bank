using System.Collections.Generic;

namespace MiASI_Bank
{
    public class Bank : IBank
    {
        #region Pola prywatne

        private List<ProduktBankowy> _produktyBankowe = new List<ProduktBankowy>();

        #endregion

        #region Metody

        public bool DodajRachunek(Wlasciciel wlasciciel)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            if (rachunek == null)
            {
                rachunek = new RachunekBankowy {Wlasciciel = wlasciciel};

                _produktyBankowe.Add(rachunek);

                result = true;
            }

            return result;
        }

        public bool ZamknijRachunek(Wlasciciel wlasciciel)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            if (rachunek != null)
            {
                result = rachunek.Zamknij();
            }

            return result;
        }

        public bool DodajLokate(Wlasciciel wlasciciel, Kwota kwota)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            if (rachunek != null)
            {
                result = rachunek.DodajLokate(kwota);
            }

            return result;
        }

        public bool ZerwijLokate(NumerProduktu numerProduktu)
        {
            bool result = false;

            var lokata = SzukajProduktu(numerProduktu) as Lokata;

            if (lokata != null)
            {
                result = lokata.Zerwij();
            }

            return result;
        }

        public bool DodajKredyt(Wlasciciel wlasciciel, Kwota kwota)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            if (rachunek != null)
            {
                result = rachunek.DodajKredyt(kwota);
            }

            return result;
        }

        public bool WykonajPrzelew(RachunekBankowy zrodlo, RachunekBankowy cel, Kwota kwota)
        {
            bool result = false;

            if(zrodlo.Saldo.Wartosc >= kwota.Wartosc)
            {
                WyplacGotowke(zrodlo, kwota);
                WplacGotowke(cel, kwota);

                result = true;
            }

            return result;
        }

        public bool WplacGotowke(RachunekBankowy cel, Kwota kwota)
        {
            return cel.WplacGotowke(kwota);
        }

        public bool WyplacGotowke(RachunekBankowy zrodlo, Kwota kwota)
        {
            return zrodlo.WyplacGotowke(kwota);
        }

        public Raport GenerujRaport()
        {
            var raportowanie = new Raportowanie();

            var raport = raportowanie.GenerujRaport(_produktyBankowe);

            return raport;
        }

        public Raport PobierzSaldo(RachunekBankowy produkt)
        {
            var raportowanie = new Raportowanie();

            var raport = raportowanie.GenerujRaport(produkt);

            return raport;
        }

        #region Szukanie

        private RachunekBankowy SzukajRachunku(Wlasciciel wlasciciel)
        {
            RachunekBankowy result;

            result =
                _produktyBankowe.Find(p => p is RachunekBankowy rachunek && rachunek.Wlasciciel == wlasciciel) as
                    RachunekBankowy;

            return result;
        }


        private ProduktBankowy SzukajProduktu(NumerProduktu numerProduktu)
        {
            ProduktBankowy result;

            result = _produktyBankowe.Find(p => p.Numer == numerProduktu);

            return result;
        }

        #endregion

        #endregion
    }
}