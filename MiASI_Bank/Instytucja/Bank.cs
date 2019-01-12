using System.Collections.Generic;
using MiASI_Bank.Instytucja.Interfejsy;
using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;
using MiASI_Bank.Produkt;
using MiASI_Bank.Produkt.Fabryki;
using MiASI_Bank.Produkt.Fabryki.Interfejsy;
using MiASI_Bank.Produkt.Interfejsy;
using MiASI_Bank.Raporty;

namespace MiASI_Bank.Instytucja
{
    public class Bank : IBank
    {
        #region Pola prywatne

        private List<IProduktBankowy> _produktyBankowe = new List<IProduktBankowy>();
        private readonly IFabrykaRachunkow _fabrykaRachunkow;

        #endregion
        
        #region Constructors

        public Bank(IFabrykaRachunkow fabrykaRachunkow)
        {
            _fabrykaRachunkow = fabrykaRachunkow;
        }
        
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

        public bool PodajLiczbeLokat(IWlasciciel wlasciciel, out int liczbaLokat)
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

        public IRachunekBankowy PobierzRachunek(IWlasciciel wlasciciel)
        {
            return SzukajRachunku(wlasciciel);
        }

        public bool DodajRachunek(IWlasciciel wlasciciel, out IRachunekBankowy rachunek)
        {
            bool result = false;

            rachunek = SzukajRachunku(wlasciciel);

            if (rachunek == null)
            {
                rachunek = _fabrykaRachunkow.StworzRachunek(wlasciciel);

                _produktyBankowe.Add(rachunek);

                result = true;
            }

            return result;
        }

        public bool ZamknijRachunek(IWlasciciel wlasciciel)
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

        public bool DodajLokate(IWlasciciel wlasciciel, Kwota kwota, out Lokata lokata)
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

        public bool ZerwijLokate(IWlasciciel wlasciciel, NumerProduktu numerProduktu)
        {
            var rachunek = SzukajRachunku(wlasciciel);

            var result = rachunek.ZerwijLokate(numerProduktu);

            return result;
        }

        public bool DodajKredyt(IWlasciciel wlasciciel, Kwota kwota)
        {
            bool result = false;

            var rachunek = SzukajRachunku(wlasciciel);

            if (rachunek != null)
            {
                result = rachunek.DodajKredyt(kwota);
            }

            return result;
        }

        public bool WykonajPrzelew(IRachunekBankowy zrodlo, IRachunekBankowy cel, Kwota kwota)
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

        public bool WplacGotowke(IRachunekBankowy cel, Kwota kwota)
        {
            return cel.WplacGotowke(kwota);
        }

        public bool WyplacGotowke(IRachunekBankowy zrodlo, Kwota kwota)
        {
            return zrodlo.WyplacGotowke(kwota);
        }

        public Raport GenerujRaport()
        {
            var raportowanie = new Raportowanie();

            var raport = raportowanie.GenerujRaport(_produktyBankowe);

            return raport;
        }

        public Raport PobierzSaldo(IRachunekBankowy produkt)
        {
            var raportowanie = new Raportowanie();

            var raport = raportowanie.GenerujRaport(produkt);

            return raport;
        }

        #region Szukanie

        private IRachunekBankowy SzukajRachunku(IWlasciciel wlasciciel)
        {
            return _produktyBankowe.Find(p => p is IRachunekBankowy rachunek && rachunek.Wlasciciel.Id == wlasciciel.Id)
                as IRachunekBankowy;
        }


        private IProduktBankowy SzukajProduktu(NumerProduktu numerProduktu)
        {
            IProduktBankowy result;

            result = _produktyBankowe.Find(p => p.Numer == numerProduktu);

            return result;
        }

        #endregion

        #endregion
    }
}