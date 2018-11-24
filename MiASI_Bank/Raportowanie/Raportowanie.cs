using System.Collections.Generic;

namespace MiASI_Bank
{
    public class Raportowanie
    {
        public Raport GenerujRaport(IProduktBankowy produkt)
        {
            var raport = new Raport();

            return raport;
        }
        public Raport GenerujRaport(IEnumerable<IProduktBankowy> produkty)
        {
            var raport = new Raport();

            foreach (var produkt in produkty)
            {
                raport.DodajWpis($"{produkt.Numer}:{produkt.Saldo}");
            }

            return raport;
        }
    }
}