using System.Transactions;

namespace MiASI_Bank
{
    public class Bank
    {
        public bool DodajRachunek()
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
        
    }
}