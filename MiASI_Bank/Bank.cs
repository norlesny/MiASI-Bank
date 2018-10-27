using System.Collections.Generic;
using System.Transactions;

namespace MiASI_Bank
{
    public class Bank
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

        private RachunekBankowy SzukajRachunku(Wlasciciel wlasciciel)
        {
            RachunekBankowy result;
            
            result = _produktyBankowe.Find(p => p is RachunekBankowy rachunek && rachunek.Wlasciciel == wlasciciel) as RachunekBankowy;
            
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

        public bool ZerwijLokate(Wlasciciel wlasciciel, Lokata lokata)
        {
            return false;
        }
        
        public bool DodajKredyt(RachunekBankowy rachunek)
        {
            return false;
        }

        public bool WykonajPrzelew(ProduktBankowy zrodlo, ProduktBankowy cel, Kwota kwota)
        {
            return false;
        }

        public bool WplacGotowke(ProduktBankowy cel, Kwota kwota)
        {
            return false;
        }
        
        public bool WyplacGotowke(ProduktBankowy zrodlo, Kwota kwota)
        {
            return false;
        }
        
        public bool GenerujRaport()
        {
            return false;
        }

        public Raport PobierzSaldo(ProduktBankowy produkt)
        {
            var raportowanie = new Raportowanie(); 
                
            var raport = raportowanie.GenerujRaport(produkt);
            
            return raport;
        }
        
        #endregion
    }
}