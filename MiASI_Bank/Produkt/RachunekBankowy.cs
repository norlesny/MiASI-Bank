using System;
using System.Collections.Generic;
using System.Linq;
using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;
using MiASI_Bank.Produkt.Interfejsy;

namespace MiASI_Bank.Produkt
{
    public class RachunekBankowy : ProduktBankowy, IRachunekBankowy
    {
        public RachunekBankowy(IWlasciciel wlasciciel)
        {
            Wlasciciel = wlasciciel;
            Saldo = new Kwota(0);
            Numer = new NumerProduktu();
            
            DataZalozenia = DateTime.Now;
            Historia = new Historia();
            Odsetki = new Odsetki();
        }
        
        public Debet Debet { get; private set; }

        private IList<Lokata> _lokaty = new List<Lokata>();
        private IList<Kredyt> _kredyty = new List<Kredyt>();

        public bool Zamknij()
        {
            var result = true;

            if(Debet != null && Debet.Kwota.Wartosc > 0.0)
            {
                result = false;
            }else if (_kredyty.Any())
            {
                result = false;
            }else if(_lokaty.Any())
            {
                // Mo?emy zamkn?? konto kiedy mamy otwarte lokaty??
                result = false;
            }

            return result;
        }

        public bool DodajLokate(Kwota kwota, out Lokata lokata)
        {
            var result = false;

            lokata = null;
            
            if(Saldo.Wartosc >= kwota.Wartosc && WyplacGotowke(kwota))
            {
                lokata = new Lokata(this, kwota);
                
                _lokaty.Add(lokata);
                
                result = true;
            }

            return result;
        }

        public bool DodajKredyt(Kwota kwota)
        {
            var result = false;

            if (WplacGotowke(kwota))
            {
                _kredyty.Add(new Kredyt(kwota));
                result = true;
            }

            return result;
        }

        public bool DodajDebet(Kwota limit)
        {
            var result = false;

            if(Debet == null)
            {
                Debet = new Debet(limit);
                result = true;
            }

            return result;
        }

        public bool PodajLiczbeLokat(out int liczbaLokat)
        {
            liczbaLokat = _lokaty.Count;

            return true;
        }

        public bool WplacGotowke(Kwota kwota)
        {
            if(Debet != null)
            {
                if (Debet.Kwota.Wartosc >= kwota.Wartosc)
                {
                    Debet.Kwota.Wartosc -= kwota.Wartosc;
                }
                else
                {
                    var pozostalaWplata = kwota.Wartosc - Debet.Kwota.Wartosc;
                    Debet.Kwota.Wartosc = 0.0;

                    Saldo.Wartosc += pozostalaWplata;
                }
            }
            else
            {
                Saldo.Wartosc += kwota.Wartosc;
            }

            return true;
        }

        public bool WyplacGotowke(Kwota kwota)
        {
            var result = false;

            if (Saldo.Wartosc >= kwota.Wartosc)
            {
                Saldo.Wartosc -= kwota.Wartosc;
                result = true;
            }
            else if(Debet != null && Saldo.Wartosc + Debet.DostepnyDebet.Wartosc >= kwota.Wartosc)
            {
                var debet = kwota.Wartosc - Saldo.Wartosc;
                Saldo.Wartosc = 0.0;

                Debet.Kwota.Wartosc += debet;

                result = true;
            }

            return result;
        }

        public bool ZerwijLokate(NumerProduktu numerProduktu)
        {
            bool result = false;
            var lokataDoZerwania = _lokaty.FirstOrDefault(lokata => lokata.Numer == numerProduktu);

            if (lokataDoZerwania != null)
            {
                if (lokataDoZerwania.Zerwij())
                {
                    result =_lokaty.Remove(lokataDoZerwania);
                }
            }

            return result;
        }
    }
}