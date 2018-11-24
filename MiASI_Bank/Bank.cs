using System.Collections.Generic;

namespace MiASI_Bank
{
    public class Bank : IBank
    {
        #region Pola prywatne

        private List<ProduktBankowy> _produktyBankowe = new List<ProduktBankowy>();

        #endregion

        #region Wlasciwosci

        public int LiczbaRachunkow => _produktyBankowe.Count;

        #endregion
        
        #region Metody

        public bool PodajLiczbeRachunkow(out int liczbaRachunkow)
        {
            liczbaRachunkow = LiczbaRachunkow;

            return true;
        }

        public bool PodajLiczbeLokat(Wlasciciel wlasciciel, out int liczbaLokat)
        {
            bool result = false;
            var rachunek = SzukajRachunku(wlasciciel);

            liczbaLokat = 0;

            if (rachunek != null)
            {
                result = rachunek.PodajLiczbeLokat(out liczbaLokat);
            }

            return result;
        }

        public bool DodajRachunek(Wlasciciel wlasciciel, out RachunekBankowy rachunek)
        {
            bool result = false;

            rachunek = SzukajRachunku(wlasciciel);

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

                if (result)
                {
                    result = _produktyBankowe.Remove(rachunek);
                }
            }

            return result;
        }

        public bool DodajLokate(Wlasciciel wlasciciel, Kwota kwota, out Lokata lokata)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            lokata = null;

            if (rachunek != null)
            {
                result = rachunek.DodajLokate(kwota, out lokata);
            }

            return result;
        }

        public bool ZerwijLokate(Wlasciciel wlasciciel, NumerProduktu numerProduktu)
        {
            var rachunek = SzukajRachunku(wlasciciel);

            var result = rachunek.ZerwijLokate(numerProduktu);

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