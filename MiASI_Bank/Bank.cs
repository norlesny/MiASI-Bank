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
        
        public bool DodajRachunek(RachunekBankowy rachunek)
        {
            return false;
        }
        
        public bool ZamknijRachunek(RachunekBankowy rachunek)
        {
            return false;
        }
        
        public bool DodajLokate(RachunekBankowy rachunek)
        {
            return false;
        }

        public bool ZerwijLokate(Lokata lokata)
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